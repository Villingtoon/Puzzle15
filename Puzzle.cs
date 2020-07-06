using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puzzle15
{
    public partial class Puzzle : Form
    {
        public Puzzle()
        {
            InitializeComponent();
            InitializePuzzle();
            AddButtons();
        }

        private void InitializePuzzle()
        {
            this.BackColor = Color.Lime;
            this.Text = "Puzzle15";
            this.ClientSize = new Size(500, 500);
        }

        private void AddButtons()
        {
            int blockCount = 1;
            PuzzleBlock block;
            for(int row = 1; row < 5; row++)
            {
                for (int col = 1; col < 5; col++)
                {
                    block = new PuzzleBlock();
                    block.Top = row * 85;
                    block.Left = col * 85;
                    block.Text = blockCount.ToString();
                    //block.Name = "block" + blockCount.ToString();


                    //block.Click += new EventHandler(Block_Click);
                    block.Click += Block_Click;

                    if(blockCount == 16)
                    {
                        block.Name = "EmptyBlock";
                        block.Text = string.Empty;
                        block.BackColor = Color.Lime;
                        block.FlatStyle = FlatStyle.Flat;
                        block.FlatAppearance.BorderSize = 0;
                    }
                    blockCount++;
                    this.Controls.Add(block);
                }
            }
        }

        private void Block_Click(object sender, EventArgs e)
        {
            Button block = (Button)sender;
            SwapBlocks(block);
        }

        private void SwapBlocks(Button block)
        {
            Button emptyBlock = (Button)this.Controls["EmptyBlock"];
            Point oldLocation = block.Location;
            block.Location = emptyBlock.Location;
            emptyBlock.Location = oldLocation;
        }
    }
}
