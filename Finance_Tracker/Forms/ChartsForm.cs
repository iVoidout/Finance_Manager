using Finance_Tracker.Helpers;
using Finance_Tracker.Models;
using Microsoft.Web.WebView2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Finance_Tracker.Forms
{
    public partial class ChartsForm : Form
    {
        private readonly List<AppTransaction> _transactions;

        public ChartsForm(List<AppTransaction> transactions)
        {
            InitializeComponent();
            _transactions = transactions;
        }

        private async void ChartsForm_Load(object sender, EventArgs e)
        {
            await webView1.EnsureCoreWebView2Async(null);
            webView1.NavigateToString(BuildHtml());

            //await webView1.EnsureCoreWebView2Async(null);
            //webView1.NavigateToString(BuildHtmlPie());

            //await webView22.EnsureCoreWebView2Async(null);
            //webView22.NavigateToString(BuildHtmlBar());
        }
        private string BuildHtml()
        {
            string chartJs = ResourceHelper.GetChartJs();

            // pie chart data — expenses by category
            var grouped = _transactions
                .Where(t => t.Type == "Expense")
                .GroupBy(t => t.Category)
                .Select(g => new { Category = g.Key, Total = g.Sum(t => t.Amount) })
                .OrderByDescending(g => g.Total)
                .ToList();

            string pieLabels = grouped.Count > 0
                ? string.Join(",", grouped.Select(g => $"'{g.Category}'"))
                : "'هیچ داده‌ای وجود ندارد'";
            string pieValues = grouped.Count > 0
                ? string.Join(",", grouped.Select(g => g.Total))
                : "0";

            // monthly income vs expense bar
            var months = _transactions
                .GroupBy(t => new { t.Date.Year, t.Date.Month })
                .OrderBy(g => g.Key.Year)
                .ThenBy(g => g.Key.Month)
                .ToList();

            string barLabels = months.Count > 0
                ? string.Join(",", months.Select(m => $"'{m.Key.Year}/{m.Key.Month:D2}'"))
                : "'هیچ داده‌ای وجود ندارد'";
            string barIncome = months.Count > 0
                ? string.Join(",", months.Select(m => m.Where(t => t.Type == "Income").Sum(t => t.Amount)))
                : "0";
            string barExpense = months.Count > 0
                ? string.Join(",", months.Select(m => m.Where(t => t.Type == "Expense").Sum(t => t.Amount)))
                : "0";

            // monthly spending trend (line)
            string spendingTrendValues = months.Count > 0
                ? string.Join(",", months.Select(m => m.Where(t => t.Type == "Expense").Sum(t => t.Amount)))
                : "0";

            // monthly income trend (line)
            string incomeTrendValues = months.Count > 0
                ? string.Join(",", months.Select(m => m.Where(t => t.Type == "Income").Sum(t => t.Amount)))
                : "0";

            return $@"<!DOCTYPE html>
                    <html dir='rtl'>
                    <head>
                    <meta charset='utf-8'>
                    <style>
                      * {{ margin: 0; padding: 0; box-sizing: border-box; }}
                      body {{ font-family: Tahoma, sans-serif; background: #f5f5f5; }}
  
                      .tabs {{
                        display: flex;
                        background: white;
                        border-bottom: 1px solid #e0e0e0;
                      }}
                      .tab-btn {{
                        flex: 1;
                        padding: 14px;
                        text-align: center;
                        cursor: pointer;
                        font-size: 13px;
                        font-weight: bold;
                        color: #888;
                        border-bottom: 3px solid transparent;
                      }}
                      .tab-btn.active {{
                        color: #1A1A2E;
                        border-bottom-color: #1A1A2E;
                      }}
  
                      .tab-content {{ display: none; padding: 24px; }}
                      .tab-content.active {{ display: block; }}
  
                      .chart-box {{ 
                        background: white; 
                        border-radius: 12px; 
                        padding: 24px; 
                        box-shadow: 0 2px 8px rgba(0,0,0,0.08); 
                      }}
                      h2 {{ 
                        color: #1A1A2E; 
                        margin-bottom: 16px; 
                        font-size: 15px; 
                        text-align: center;
                        font-weight: bold;
                      }}
                      .chart-wrapper {{
                        position: relative;
                        height: 320px;
                      }}
                    </style>
                    </head>
                    <body>

                    <div class='tabs'>
                      <div class='tab-btn active' onclick='showTab(0)'>دسته‌بندی هزینه‌ها</div>
                      <div class='tab-btn' onclick='showTab(1)'>درآمد و هزینه ماهانه</div>
                      <div class='tab-btn' onclick='showTab(2)'>روند هزینه ماهانه</div>
                      <div class='tab-btn' onclick='showTab(3)'>روند درآمد ماهانه</div>
                    </div>

                    <div class='tab-content active' id='tab0'>
                      <div class='chart-box'>
                        <h2>هزینه‌ها بر اساس دسته‌بندی</h2>
                        <div class='chart-wrapper'><canvas id='pieChart'></canvas></div>
                      </div>
                    </div>

                    <div class='tab-content' id='tab1'>
                      <div class='chart-box'>
                        <h2>درآمد و هزینه ماهانه</h2>
                        <div class='chart-wrapper'><canvas id='barChart'></canvas></div>
                      </div>
                    </div>

                    <div class='tab-content' id='tab2'>
                      <div class='chart-box'>
                        <h2>روند هزینه ماهانه</h2>
                        <div class='chart-wrapper'><canvas id='spendingTrendChart'></canvas></div>
                      </div>
                    </div>

                    <div class='tab-content' id='tab3'>
                      <div class='chart-box'>
                        <h2>روند درآمد ماهانه</h2>
                        <div class='chart-wrapper'><canvas id='incomeTrendChart'></canvas></div>
                      </div>
                    </div>

                    <script>{chartJs}</script>
                    <script>
                    function showTab(index) {{
                      document.querySelectorAll('.tab-btn').forEach((el, i) => el.classList.toggle('active', i === index));
                      document.querySelectorAll('.tab-content').forEach((el, i) => el.classList.toggle('active', i === index));
                    }}

                    new Chart(document.getElementById('pieChart'), {{
                      type: 'doughnut',
                      data: {{
                        labels: [{pieLabels}],
                        datasets: [{{
                          data: [{pieValues}],
                          backgroundColor: ['#2D6A4F','#C0392B','#1A1A2E','#E67E22','#8E44AD','#2980B9','#27AE60','#E74C3C'],
                          borderWidth: 2,
                          borderColor: '#ffffff'
                        }}]
                      }},
                      options: {{
                        responsive: true,
                        maintainAspectRatio: false,
                        plugins: {{ legend: {{ position: 'bottom', labels: {{ font: {{ family: 'Tahoma', size: 12 }}, padding: 16 }} }} }}
                      }}
                    }});

                    new Chart(document.getElementById('barChart'), {{
                      type: 'bar',
                      data: {{
                        labels: [{barLabels}],
                        datasets: [
                          {{ label: 'درآمد', data: [{barIncome}], backgroundColor: '#2D6A4F', borderRadius: 6 }},
                          {{ label: 'هزینه', data: [{barExpense}], backgroundColor: '#C0392B', borderRadius: 6 }}
                        ]
                      }},
                      options: {{
                        responsive: true,
                        maintainAspectRatio: false,
                        plugins: {{ legend: {{ position: 'bottom', labels: {{ font: {{ family: 'Tahoma', size: 12 }}, padding: 16 }} }} }},
                        scales: {{ y: {{ beginAtZero: true, grid: {{ color: '#f0f0f0' }} }}, x: {{ grid: {{ display: false }} }} }}
                      }}
                    }});

                    new Chart(document.getElementById('spendingTrendChart'), {{
                      type: 'line',
                      data: {{
                        labels: [{barLabels}],
                        datasets: [{{
                          label: 'هزینه ماهانه',
                          data: [{spendingTrendValues}],
                          borderColor: '#C0392B',
                          backgroundColor: 'rgba(192,57,43,0.1)',
                          fill: true,
                          tension: 0.3,
                          pointBackgroundColor: '#C0392B',
                          pointRadius: 4
                        }}]
                      }},
                      options: {{
                        responsive: true,
                        maintainAspectRatio: false,
                        plugins: {{ legend: {{ position: 'bottom', labels: {{ font: {{ family: 'Tahoma', size: 12 }} }} }} }},
                        scales: {{ y: {{ beginAtZero: true, grid: {{ color: '#f0f0f0' }} }}, x: {{ grid: {{ display: false }} }} }}
                      }}
                    }});

                    new Chart(document.getElementById('incomeTrendChart'), {{
                      type: 'line',
                      data: {{
                        labels: [{barLabels}],
                        datasets: [{{
                          label: 'درآمد ماهانه',
                          data: [{incomeTrendValues}],
                          borderColor: '#2D6A4F',
                          backgroundColor: 'rgba(45,106,79,0.1)',
                          fill: true,
                          tension: 0.3,
                          pointBackgroundColor: '#2D6A4F',
                          pointRadius: 4
                        }}]
                      }},
                      options: {{
                        responsive: true,
                        maintainAspectRatio: false,
                        plugins: {{ legend: {{ position: 'bottom', labels: {{ font: {{ family: 'Tahoma', size: 12 }} }} }} }},
                        scales: {{ y: {{ beginAtZero: true, grid: {{ color: '#f0f0f0' }} }}, x: {{ grid: {{ display: false }} }} }}
                      }}
                    }});
                    </script>
                    </body>
                    </html>";
        }
        //private string BuildHtmlPie()
        //{
        //    string chartJs = ResourceHelper.GetChartJs();

        //    // pie chart data
        //    var grouped = _transactions
        //        .Where(t => t.Type == "Expense")
        //        .GroupBy(t => t.Category)
        //        .Select(g => new { Category = g.Key, Total = g.Sum(t => t.Amount) })
        //        .OrderByDescending(g => g.Total)
        //        .ToList();

        //    string pieLabels = grouped.Count > 0
        //        ? string.Join(",", grouped.Select(g => $"'{g.Category}'"))
        //        : "'هیچ داده‌ای وجود ندارد'";
        //    string pieValues = grouped.Count > 0
        //        ? string.Join(",", grouped.Select(g => g.Total))
        //        : "0";

        //    return $@"<!DOCTYPE html>
        //            <html dir='rtl'>
        //            <head>
        //            <meta charset='utf-8'>
        //            <style>
        //              * {{ margin: 0; padding: 0; box-sizing: border-box; }}
        //              body {{ 
        //                font-family: Tahoma, sans-serif; 
        //                background: #f5f5f5; 
        //                padding: 20px;
        //                overflow-y: auto;
        //              }}
        //              .container {{ display: flex; flex-direction: column; gap: 30px; }}
        //              .chart-box {{ 
        //                background: white; 
        //                border-radius: 12px; 
        //                padding: 24px; 
        //                box-shadow: 0 2px 8px rgba(0,0,0,0.08); 
        //              }}
        //              h2 {{ 
        //                color: #1A1A2E; 
        //                margin-bottom: 16px; 
        //                font-size: 15px; 
        //                text-align: center;
        //                font-weight: bold;
        //              }}
        //              .chart-wrapper {{
        //                position: relative;
        //                height: 280px;
        //              }}
        //            </style>
        //            </head>
        //            <body>
        //            <div class='container'>
        //              <div class='chart-box'>
        //                <h2>هزینه‌ها بر اساس دسته‌بندی</h2>
        //                <div class='chart-wrapper'>
        //                  <canvas id='pieChart'></canvas>
        //                </div>
        //              </div>

        //            <script>{chartJs}</script>
        //            <script>
        //              new Chart(document.getElementById('pieChart'), {{
        //                type: 'doughnut',
        //                data: {{
        //                  labels: [{pieLabels}],
        //                  datasets: [{{
        //                    data: [{pieValues}],
        //                    backgroundColor: [
        //                      '#2D6A4F','#C0392B','#1A1A2E','#E67E22',
        //                      '#8E44AD','#2980B9','#27AE60','#E74C3C'
        //                    ],
        //                    borderWidth: 2,
        //                    borderColor: '#ffffff'
        //                  }}]
        //                }},
        //                options: {{
        //                  responsive: true,
        //                  maintainAspectRatio: false,
        //                  plugins: {{
        //                    legend: {{ 
        //                      position: 'bottom',
        //                      labels: {{
        //                        font: {{ family: 'Tahoma', size: 12 }},
        //                        padding: 16
        //                      }}
        //                    }}
        //                  }}
        //                }}
        //              }});

        //            </script>
        //            </body>
        //            </html>";
        //}

        //private string BuildHtmlBar()
        //{
        //    string chartJs = ResourceHelper.GetChartJs();

        //    // bar chart data
        //    var months = _transactions
        //        .GroupBy(t => new { t.Date.Year, t.Date.Month })
        //        .OrderBy(g => g.Key.Year)
        //        .ThenBy(g => g.Key.Month)
        //        .ToList();

        //    string barLabels = months.Count > 0
        //        ? string.Join(",", months.Select(m => $"'{m.Key.Year}/{m.Key.Month:D2}'"))
        //        : "'هیچ داده‌ای وجود ندارد'";
        //    string barIncome = months.Count > 0
        //        ? string.Join(",", months.Select(m => m.Where(t => t.Type == "Income").Sum(t => t.Amount)))
        //        : "0";
        //    string barExpense = months.Count > 0
        //        ? string.Join(",", months.Select(m => m.Where(t => t.Type == "Expense").Sum(t => t.Amount)))
        //        : "0";

        //    return $@"<!DOCTYPE html>
        //            <html dir='rtl'>
        //            <head>
        //            <meta charset='utf-8'>
        //            <style>
        //              * {{ margin: 0; padding: 0; box-sizing: border-box; }}
        //              body {{ 
        //                font-family: Tahoma, sans-serif; 
        //                background: #f5f5f5; 
        //                padding: 20px;
        //                overflow-y: auto;
        //              }}
        //              .container {{ display: flex; flex-direction: column; gap: 30px; }}
        //              .chart-box {{ 
        //                background: white; 
        //                border-radius: 12px; 
        //                padding: 24px; 
        //                box-shadow: 0 2px 8px rgba(0,0,0,0.08); 
        //              }}
        //              h2 {{ 
        //                color: #1A1A2E; 
        //                margin-bottom: 16px; 
        //                font-size: 15px; 
        //                text-align: center;
        //                font-weight: bold;
        //              }}
        //              .chart-wrapper {{
        //                position: relative;
        //                height: 280px;
        //              }}
        //            </style>
        //            </head>
        //            <body>
        //              <div class='chart-box'>
        //                <h2>درآمد و هزینه ماهانه</h2>
        //                <div class='chart-wrapper'>
        //                  <canvas id='barChart'></canvas>
        //                </div>
        //              </div>
        //            </div>
        //            <script>{chartJs}</script>
        //            <script>

        //              new Chart(document.getElementById('barChart'), {{
        //                type: 'bar',
        //                data: {{
        //                  labels: [{barLabels}],
        //                  datasets: [
        //                    {{
        //                      label: 'درآمد',
        //                      data: [{barIncome}],
        //                      backgroundColor: '#2D6A4F',
        //                      borderRadius: 6
        //                    }},
        //                    {{
        //                      label: 'هزینه',
        //                      data: [{barExpense}],
        //                      backgroundColor: '#C0392B',
        //                      borderRadius: 6
        //                    }}
        //                  ]
        //                }},
        //                options: {{
        //                  responsive: true,
        //                  maintainAspectRatio: false,
        //                  plugins: {{
        //                    legend: {{ 
        //                      position: 'bottom',
        //                      labels: {{
        //                        font: {{ family: 'Tahoma', size: 12 }},
        //                        padding: 16
        //                      }}
        //                    }}
        //                  }},
        //                  scales: {{
        //                    y: {{ 
        //                      beginAtZero: true,
        //                      grid: {{ color: '#f0f0f0' }}
        //                    }},
        //                    x: {{
        //                      grid: {{ display: false }}
        //                    }}
        //                  }}
        //                }}
        //              }});
        //            </script>
        //            </body>
        //            </html>";
        //}
    }
}
