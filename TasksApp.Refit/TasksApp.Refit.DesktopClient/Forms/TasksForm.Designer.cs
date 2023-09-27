namespace TasksApp.Refit.DesktopClient.Forms
{
    partial class TasksForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtTask = new TextBox();
            btnAddTask = new Button();
            btnDelete = new Button();
            lstTasks = new ListBox();
            btnLogout = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(255, 9);
            label1.Name = "label1";
            label1.Size = new Size(146, 45);
            label1.TabIndex = 0;
            label1.Text = "My Tasks";
            // 
            // txtTask
            // 
            txtTask.Location = new Point(31, 64);
            txtTask.Name = "txtTask";
            txtTask.Size = new Size(154, 23);
            txtTask.TabIndex = 2;
            // 
            // btnAddTask
            // 
            btnAddTask.Location = new Point(31, 93);
            btnAddTask.Name = "btnAddTask";
            btnAddTask.Size = new Size(154, 23);
            btnAddTask.TabIndex = 3;
            btnAddTask.Text = "Add";
            btnAddTask.UseVisualStyleBackColor = true;
            btnAddTask.Click += btnAddTask_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(31, 154);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(154, 28);
            btnDelete.TabIndex = 0;
            btnDelete.Text = "Delete Task";
            btnDelete.Click += btnDelete_Click;
            // 
            // lstTasks
            // 
            lstTasks.FormattingEnabled = true;
            lstTasks.ItemHeight = 15;
            lstTasks.Location = new Point(231, 64);
            lstTasks.Name = "lstTasks";
            lstTasks.Size = new Size(187, 304);
            lstTasks.TabIndex = 4;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(31, 345);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(75, 23);
            btnLogout.TabIndex = 5;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // Tasks
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(521, 450);
            Controls.Add(btnLogout);
            Controls.Add(lstTasks);
            Controls.Add(btnDelete);
            Controls.Add(btnAddTask);
            Controls.Add(txtTask);
            Controls.Add(label1);
            Name = "Tasks";
            Text = "Tasks";
            Load += Tasks_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtTask;
        private Button btnAddTask;
        private Button btnDelete;
        private ListBox lstTasks;
        private Button btnLogout;
    }
}