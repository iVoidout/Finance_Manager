using Finance_Tracker.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2;

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
            
        }

        private string BuildHtml()
        {
            // pie chart data
            var grouped = _transactions
                .Where(t => t.Type == "Expense")
                .GroupBy(t => t.Category)
                .Select(g => new { Category = g.Key, Total = g.Sum(t => t.Amount) })
                .OrderByDescending(g => g.Total)
                .ToList();

            string pieLabels = string.Join(",", grouped.Select(g => $"'{g.Category}'"));
            string pieValues = string.Join(",", grouped.Select(g => g.Total));

            // bar chart data
            var months = _transactions
                .GroupBy(t => new { t.Date.Year, t.Date.Month })
                .OrderBy(g => g.Key.Year)
                .ThenBy(g => g.Key.Month)
                .ToList();

            string barLabels = string.Join(",", months.Select(m => $"'{m.Key.Year}/{m.Key.Month:D2}'"));
            string barIncome = string.Join(",", months.Select(m => m.Where(t => t.Type == "Income").Sum(t => t.Amount)));
            string barExpense = string.Join(",", months.Select(m => m.Where(t => t.Type == "Expense").Sum(t => t.Amount)));

            return $@"
            <!DOCTYPE html>
            <html dir='rtl'>
            <head>
            <meta charset='utf-8'>
            <script src='https://cdn.jsdelivr.net/npm/chart.js'></script>
            <style>
              * {{ margin: 0; padding: 0; box-sizing: border-box; }}
              body {{ font-family: Tahoma, sans-serif; background: #f5f5f5; padding: 20px; }}
              .container {{ display: flex; flex-direction: column; gap: 40px; }}
              .chart-box {{ background: white; border-radius: 12px; padding: 20px; box-shadow: 0 2px 8px rgba(0,0,0,0.08); }}
              h2 {{ color: #1A1A2E; margin-bottom: 16px; font-size: 16px; text-align: center; }}
              canvas {{ max-height: 300px; }}
            </style>
            </head>
            <body>
            <div class='container'>
              <div class='chart-box'>
                <h2>هزینه‌ها بر اساس دسته‌بندی</h2>
                <canvas id='pieChart'></canvas>
              </div>
              <div class='chart-box'>
                <h2>درآمد و هزینه ماهانه</h2>
                <canvas id='barChart'></canvas>
              </div>
            </div>
            <script>
              new Chart(document.getElementById('pieChart'), {{
                type: 'doughnut',
                data: {{
                  labels: [{pieLabels}],
                  datasets: [{{
                    data: [{pieValues}],
                    backgroundColor: [
                      '#2D6A4F','#C0392B','#1A1A2E','#E67E22',
                      '#8E44AD','#2980B9','#27AE60','#E74C3C'
                    ]
                  }}]
                }},
                options: {{
                  plugins: {{
                    legend: {{ position: 'bottom' }}
                  }}
                }}
              }});

              new Chart(document.getElementById('barChart'), {{
                type: 'bar',
                data: {{
                  labels: [{barLabels}],
                  datasets: [
                    {{
                      label: 'درآمد',
                      data: [{barIncome}],
                      backgroundColor: '#2D6A4F'
                    }},
                    {{
                      label: 'هزینه',
                      data: [{barExpense}],
                      backgroundColor: '#C0392B'
                    }}
                  ]
                }},
                options: {{
                  plugins: {{
                    legend: {{ position: 'bottom' }}
                  }},
                  scales: {{
                    y: {{ beginAtZero: true }}
                  }}
                }}
              }});
            </script>
            </body>
            </html>";
        }
    }

}
