using CRUD_Opeartions;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProjectB
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();

            // Getting Clo Id FOR Rubric
            var con = Configuration.getInstance().getConnection();
            SqlCommand sc = new SqlCommand("Select id from CLO", con);
            List<String> data = new List<string>();

            SqlDataReader reader = sc.ExecuteReader();
            while (reader.Read())
            {
                data.Add(reader.GetValue(0).ToString());
            }
            reader.Close();
            comboBox2.DataSource = data;

            // Getting AssessmentId FOR Assessment Component
            SqlCommand sc1 = new SqlCommand("Select DISTINCT Id from Assessment", con);
            List<String> data1 = new List<string>();
            data.Clear();
            SqlDataReader reader1 = sc1.ExecuteReader();
            while (reader1.Read())
            {
                data.Add(reader1.GetValue(0).ToString());
            }
            reader1.Close();
            comboBox3.DataSource = data;

            // Getting RubricId FOR Assessment Component
            SqlCommand sc2 = new SqlCommand("Select DISTINCT Id from Rubric", con);
            List<String> data2 = new List<string>();
            data.Clear();
            SqlDataReader reader2 = sc2.ExecuteReader();
            while (reader2.Read())
            {
                data.Add(reader2.GetValue(0).ToString());
            }
            reader2.Close();
            comboBox4.DataSource = data;


            // Getting RubricId FOR Rubric Level
            SqlCommand sc3 = new SqlCommand("Select DISTINCT Id from Rubric", con);
            List<String> data3 = new List<string>();
            data.Clear();

            SqlDataReader reader3 = sc3.ExecuteReader();
            while (reader3.Read())
            {
                data.Add(reader3.GetValue(0).ToString());
            }
            reader3.Close();
            comboBox5.DataSource = data;

            //Getting LookUpid For  Student Status
            SqlCommand sc4 = new SqlCommand("SELECT CONCAT([LookupId], ', ', [Name]) FROM Lookup Where Category = 'STUDENT_STATUS'", con);
            List<String> data4 = new List<string>();
            data.Clear();
            SqlDataReader reader4 = sc4.ExecuteReader();
            while (reader4.Read())
            {
                data.Add(reader4.GetValue(0).ToString());

            }
            reader4.Close();
            comboBox1.DataSource = data;
               
            //Getting Rubric Measurement Id For  Student Result
            SqlCommand sc5 = new SqlCommand("Select RubricId From RubricLevel", con);
            List<String> data5 = new List<string>();
            data.Clear();
            SqlDataReader reader5 = sc5.ExecuteReader();
            while (reader5.Read())
            {
                data.Add(reader5.GetValue(0).ToString());

            }
            reader5.Close();
            comboBox6.DataSource = data;


            //Getting StudentId For  Student Result
            SqlCommand sc6 = new SqlCommand("Select Id From Student", con);
            List<String> data6 = new List<string>();
            data.Clear();
            SqlDataReader reader6 = sc6.ExecuteReader();
            while (reader6.Read())
            {
                data.Add(reader6.GetValue(0).ToString());

            }
            reader6.Close();
            comboBox8.DataSource = data;


            //Getting Assessment Component Id For  Student Result
            SqlCommand sc7 = new SqlCommand("Select Id From AssessmentComponent ", con);
            List<String> data7 = new List<string>();
            data.Clear();
            SqlDataReader reader7 = sc7.ExecuteReader();
            while (reader7.Read())
            {
                data.Add(reader7.GetValue(0).ToString());

            }
            reader7.Close();
            comboBox7.DataSource = data;

            //Getting Lookup Id For Attendance Status 
            SqlCommand sc8 = new SqlCommand("SELECT CONCAT([LookupId] ,', ', [Name] ) FROM Lookup WHERE Category= 'ATTENDANCE_STATUS'", con);
            List<String> data8 = new List<string>();
            data.Clear();
            SqlDataReader reader8 = sc8.ExecuteReader();
            while (reader8.Read())
            {
                data.Add(reader8.GetValue(0).ToString());

            }
            reader8.Close();
            comboBox9.DataSource = data;

            //Getting StudentId For Student Attendance 
            SqlCommand sc9 = new SqlCommand("Select Id From Student", con);
            List<String> data9 = new List<string>();
            data.Clear();
            SqlDataReader reader9 = sc9.ExecuteReader();
            while (reader9.Read())
            {
                data.Add(reader9.GetValue(0).ToString());

            }
            reader9.Close();
            comboBox10.DataSource = data;

            //Getting Class attendance Id For Student Attendance 
            SqlCommand sc10 = new SqlCommand("Select Id From ClassAttendance", con);
            List<String> data10 = new List<string>();
            data.Clear();
            SqlDataReader reader10 = sc10.ExecuteReader();
            while (reader10.Read())
            {
                data.Add(reader10.GetValue(0).ToString());

            }
            reader10.Close();
            comboBox11.DataSource = data;

        }



        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'projectBDataSet8.ClassAttendance' table. You can move, or remove it, as needed.
            this.classAttendanceTableAdapter.Fill(this.projectBDataSet8.ClassAttendance);
            // TODO: This line of code loads data into the 'projectBDataSet7.Rubric' table. You can move, or remove it, as needed.
            this.rubricTableAdapter.Fill(this.projectBDataSet7.Rubric);
            // TODO: This line of code loads data into the 'projectBDataSet6.AssessmentComponent' table. You can move, or remove it, as needed.
            this.assessmentComponentTableAdapter.Fill(this.projectBDataSet6.AssessmentComponent);
            // TODO: This line of code loads data into the 'projectBDataSet5.Assessment' table. You can move, or remove it, as needed.
            this.assessmentTableAdapter.Fill(this.projectBDataSet5.Assessment);
            // TODO: This line of code loads data into the 'projectBDataSet4.RubricLevel' table. You can move, or remove it, as needed.
            this.rubricLevelTableAdapter.Fill(this.projectBDataSet4.RubricLevel);
            // TODO: This line of code loads data into the 'projectBDataSet3.StudentAttendance' table. You can move, or remove it, as needed.
            this.studentAttendanceTableAdapter.Fill(this.projectBDataSet3.StudentAttendance);
            // TODO: This line of code loads data into the 'projectBDataSet2.StudentResult' table. You can move, or remove it, as needed.
            this.studentResultTableAdapter.Fill(this.projectBDataSet2.StudentResult);
            // TODO: This line of code loads data into the 'projectBDataSet1.Clo' table. You can move, or remove it, as needed.
            this.cloTableAdapter.Fill(this.projectBDataSet1.Clo);
            // TODO: This line of code loads data into the 'projectBDataSet.Student' table. You can move, or remove it, as needed.
            this.studentTableAdapter.Fill(this.projectBDataSet.Student);

            this.reportViewer1.RefreshReport();
            this.reportViewer2.RefreshReport();
            this.reportViewer3.RefreshReport();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage6;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage5;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage4;
        }

        private void pictureBox1_Click_2(object sender, EventArgs e)
        {


        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_2(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            string reg = textBox5.Text;
            SqlCommand cmd = new SqlCommand("Delete FROM Student WHERE RegistrationNumber= '" + reg + "' ", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully Deleted");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            comboBox1.ResetText();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Update Clo set DateCreated=@DateCreated, DateUpdated=@DateUpdated where Name=@Name", con);
            cmd.Parameters.AddWithValue("@Name", textBox12.Text);
            cmd.Parameters.AddWithValue("@DateCreated", DateTime.Now);
            cmd.Parameters.AddWithValue("@DateUpdated", DateTime.Now);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully Updated");
            textBox12.Clear();
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Student", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button10_Click(object sender, EventArgs e)
        {

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into Student values (@FirstName, @LastName, @Contact, @Email, @RegistrationNumber,@Status)", con);
            cmd.Parameters.AddWithValue("@FirstName", textBox1.Text);
            cmd.Parameters.AddWithValue("@LastName", textBox2.Text);
            cmd.Parameters.AddWithValue("@Contact", textBox3.Text);
            cmd.Parameters.AddWithValue("@Email", textBox4.Text);
            cmd.Parameters.AddWithValue("@RegistrationNumber", textBox5.Text);
            cmd.Parameters.AddWithValue("@Status", comboBox1.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully Inserted");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            comboBox1.ResetText();
            textBox1.Focus();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)

        {


            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Update  Student set FirstName=@FirstName, LastName=@LastName, Contact=@Contact,  Email=@Email, Status=@Status Where  RegistrationNumber=@RegistrationNumber", con);
            cmd.Parameters.AddWithValue("@FirstName", textBox1.Text);
            cmd.Parameters.AddWithValue("@LastName", textBox2.Text);
            cmd.Parameters.AddWithValue("@Contact", textBox3.Text);
            cmd.Parameters.AddWithValue("@Email", textBox4.Text);
            cmd.Parameters.AddWithValue("@RegistrationNumber", textBox5.Text);
            cmd.Parameters.AddWithValue("@Status", comboBox1.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully Updated");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            comboBox1.ResetText();
            textBox1.Focus();




        }

        private void button14_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into Clo values (@Name , @DateCreation , @DateUpdated)", con);
            cmd.Parameters.AddWithValue("@Name", textBox12.Text);
            cmd.Parameters.AddWithValue("@DateCreation", DateTime.Now);
            cmd.Parameters.AddWithValue("@DateUpdated", DateTime.Now);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully Inserted");
            textBox12.Clear();

        }

        private void button11_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Clo", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexRow = e.RowIndex;
            DataGridViewRow row = dataGridView2.Rows[indexRow];
            textBox12.Text = row.Cells[1].Value.ToString();

        }

        private void button27_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage9;
        }

        private void button28_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage7;
        }

        private void button33_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage8;
        }

        private void button34_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }

        private void button35_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }

        private void button36_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage8;
        }

        private void button42_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage4;
        }

        private void button37_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage10;
        }

        private void button43_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select *from Student where RegistrationNumber=@RegistrationNumber", con);
            cmd.Parameters.AddWithValue("@RegistrationNumber", textBox5.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            MessageBox.Show("The Searched Data Is Displayed");
        }

        private void button59_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from RubricLevel where RubricId=@RubricId", con);
            cmd.Parameters.AddWithValue("@RubricId", int.Parse(comboBox5.Text));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView7.DataSource = dt;
            MessageBox.Show("The Searched Data Is Displayed");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            string name = textBox12.Text;
            SqlCommand cmd = new SqlCommand("Delete FROM Clo WHERE  Name= '" + name + "' ", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully Deleted");
            textBox12.Clear();
            //delete from ParentTbl
            // where ParentID Not in  
            // (select ParentID from ChildTable where ParentID is not null ) 

            //            
        }

        private void button44_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Clo  where Name=@Name", con);
            cmd.Parameters.AddWithValue("@Name", textBox12.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            MessageBox.Show("The Searched Data Is Displayed");
        }

        private void button18_Click(object sender, EventArgs e)
        {

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into Rubric values (@Id,@Details,@CloId)", con);
            cmd.Parameters.AddWithValue("@Id", int.Parse(textBox27.Text));
            cmd.Parameters.AddWithValue("@Details", textBox13.Text);
            cmd.Parameters.AddWithValue("@CloId", int.Parse(comboBox2.Text));
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully Inserted");
            textBox13.Clear();
            comboBox2.ResetText();
            textBox27.Clear();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexRow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[indexRow];
            textBox1.Text = row.Cells[1].Value.ToString();
            textBox2.Text = row.Cells[2].Value.ToString();
            textBox3.Text = row.Cells[3].Value.ToString();
            textBox4.Text = row.Cells[4].Value.ToString();
            textBox5.Text = row.Cells[5].Value.ToString();
            comboBox1.Text = row.Cells[6].Value.ToString();


        }

        private void button17_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("update Rubric set CloId=@CloId,Details=@Details where Id=@Id", con);
            cmd.Parameters.AddWithValue("@Id", int.Parse(textBox27.Text));
            cmd.Parameters.AddWithValue("@details", textBox13.Text);
            cmd.Parameters.AddWithValue("@CloId", int.Parse(comboBox2.Text));
            cmd.ExecuteNonQuery();
            MessageBox.Show("successfully updated");
            textBox13.Clear();
            comboBox2.ResetText();
            textBox27.Clear();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            string id = textBox27.Text;
            SqlCommand cmd = new SqlCommand("Delete FROM Rubric WHERE  Id= '" + id + "' ", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully Deleted");
            textBox27.Clear();
            comboBox2.ResetText();

        }

        private void button15_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Rubric", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView3.DataSource = dt;
            comboBox2.ResetText();
        }

        private void button53_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Rubric  where Id=@Id", con);
            cmd.Parameters.AddWithValue("@Id", textBox27.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView3.DataSource = dt;
            MessageBox.Show("The Searched Data Is Displayed");
            comboBox2.ResetText();
        }

        private void button48_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into Assessment values (@Title , @DateCreated , @TotalMarks,@TotalWeightage)", con);
            cmd.Parameters.AddWithValue("@Title", textBox22.Text);
            cmd.Parameters.AddWithValue("@DateCreated", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@TotalMarks", int.Parse(textBox20.Text));
            cmd.Parameters.AddWithValue("@TotalWeightage", int.Parse(textBox19.Text));
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully Inserted");
            textBox22.Clear();
            textBox20.Clear();
            textBox19.Clear();

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexRow = e.RowIndex;
            DataGridViewRow row = dataGridView3.Rows[indexRow];
            textBox27.Text = row.Cells[0].Value.ToString();
            textBox13.Text = row.Cells[1].Value.ToString();
            comboBox2.Text = row.Cells[2].Value.ToString();

        }

        private void button45_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Assessment", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView8.DataSource = dt;
        }

        private void button47_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Update Assessment set DateCreated=@DateCreated , TotalMarks=@TotalMarks,TotalWeightage=@TotalWeightage Where Title=@Title", con);
            cmd.Parameters.AddWithValue("@Title", textBox22.Text);
            cmd.Parameters.AddWithValue("@DateCreated", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@TotalMarks", int.Parse(textBox20.Text));
            cmd.Parameters.AddWithValue("@TotalWeightage", int.Parse(textBox19.Text));
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully Updated");
            textBox22.Clear();
            textBox20.Clear();
            textBox19.Clear();
        }

        private void dataGridView8_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexRow = e.RowIndex;
            DataGridViewRow row = dataGridView8.Rows[indexRow];
            textBox22.Text = row.Cells[1].Value.ToString();
            // textBox21.Text = row.Cells[2].Value.ToString();
            textBox20.Text = row.Cells[3].Value.ToString();
            textBox19.Text = row.Cells[4].Value.ToString();
        }

        private void button46_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            string title = textBox22.Text;
            SqlCommand cmd = new SqlCommand("Delete FROM Assessment WHERE  title= '" + title + "' ", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully Deleted");
            textBox22.Clear();
        }

        private void button54_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Assessment  where Title=@Title", con);
            cmd.Parameters.AddWithValue("@Title", textBox22.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView8.DataSource = dt;
            MessageBox.Show("The Searched Data Is Displayed");
        }

        private void button52_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into AssessmentComponent values (@Name, @RubricId, @TotalMarks, @DateCreated, @DateUpdated,@AssessmentId)", con);
            cmd.Parameters.AddWithValue("@Name", textBox26.Text);
            cmd.Parameters.AddWithValue("@RubricId", int.Parse(comboBox4.Text));
            cmd.Parameters.AddWithValue("@TotalMarks", int.Parse(textBox24.Text));
            cmd.Parameters.AddWithValue("@DateCreated", textBox23.Text);
            cmd.Parameters.AddWithValue("@DateUpdated", textBox18.Text);
            cmd.Parameters.AddWithValue("@AssessmentId", int.Parse(comboBox3.Text));
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully Inserted");
            textBox26.Clear();
            comboBox4.ResetText();
            textBox24.Clear();
            textBox23.Clear();
            textBox18.Clear();
            comboBox3.ResetText();

        }

        private void button49_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from AssessmentComponent", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView9.DataSource = dt;
        }

        private void dataGridView9_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexRow = e.RowIndex;
            DataGridViewRow row = dataGridView9.Rows[indexRow];
            textBox26.Text = row.Cells[1].Value.ToString();
            comboBox4.Text = row.Cells[2].Value.ToString();
            textBox24.Text = row.Cells[3].Value.ToString();
            textBox23.Text = row.Cells[4].Value.ToString();
            textBox18.Text = row.Cells[5].Value.ToString();
            comboBox3.Text = row.Cells[6].Value.ToString();
        }

        private void button51_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Update  AssessmentComponent set  Name=@Name, RubricId=@RubricId, TotalMarks=@TotalMarks, DateCreated=@DateCreated, DateUpdated=@DateUpdated where AssessmentId=@AssessmentId", con);
            cmd.Parameters.AddWithValue("@Name", textBox26.Text);
            cmd.Parameters.AddWithValue("@RubricId", int.Parse(comboBox4.Text));
            cmd.Parameters.AddWithValue("@TotalMarks", int.Parse(textBox24.Text));
            cmd.Parameters.AddWithValue("@DateCreated", textBox23.Text);
            cmd.Parameters.AddWithValue("@DateUpdated", textBox18.Text);
            cmd.Parameters.AddWithValue("@AssessmentId", int.Parse(comboBox3.Text));
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully Updated");
            textBox26.Clear();
            comboBox4.ResetText();
            textBox24.Clear();
            textBox23.Clear();
            textBox18.Clear();
            comboBox3.ResetText();
        }

        private void button50_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            string AssessmentId = comboBox3.Text;
            SqlCommand cmd = new SqlCommand("Delete FROM AssessmentComponent WHERE  AssessmentId = '" + AssessmentId + "' ", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully Deleted");
            comboBox3.ResetText();
        }

        private void button55_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from AssessmentComponent  where  AssessmentId=@AssessmentId", con);
            cmd.Parameters.AddWithValue("@AssessmentId", comboBox3.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView9.DataSource = dt;
            MessageBox.Show("The Searched Data Is Displayed");
        }

        private void button22_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into StudentResult values (@StudentId,@AssessmentComponentId,@RubricMeasurementId , @EvaluationDate)", con);
            cmd.Parameters.AddWithValue("@StudentId", int.Parse(comboBox8.Text));
            cmd.Parameters.AddWithValue("@AssessmentComponentId", int.Parse(comboBox7.Text));
            cmd.Parameters.AddWithValue("@RubricMeasurementId", int.Parse(comboBox6.Text));
            cmd.Parameters.AddWithValue("@EvaluationDate", textBox14.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully Inserted");
            comboBox6.ResetText();
            comboBox7.ResetText();
            comboBox8.ResetText();
            textBox14.Clear();

        }

        private void button21_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Update  StudentResult set StudentId=@StudentId,AssessmentComponentId=@AssessmentComponentId,EvaluationDate=@EvaluationDate where RubricMeasurementId=@RubricMeasurementId ", con);
            cmd.Parameters.AddWithValue("@StudentId", int.Parse(comboBox8.Text));
            cmd.Parameters.AddWithValue("@AssessmentComponentId", int.Parse(comboBox7.Text));
            cmd.Parameters.AddWithValue("@RubricMeasurementId", int.Parse(comboBox6.Text));
            cmd.Parameters.AddWithValue("@EvaluationDate", textBox14.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully Updated");
            comboBox6.ResetText();
            comboBox7.ResetText();
            comboBox8.ResetText();
            textBox14.Clear();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            string RubricMeasurementId = comboBox6.Text;
            SqlCommand cmd = new SqlCommand("Delete FROM StudentResult WHERE RubricMeasurementId  = '" + RubricMeasurementId + "' ", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully Deleted");
            comboBox6.ResetText();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from StudentResult", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView4.DataSource = dt;
        }

        private void button56_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from StudentResult where  RubricMeasurementId=@RubricMeasurementId", con);
            cmd.Parameters.AddWithValue("@RubricMeasurementId", int.Parse(comboBox6.Text));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView4.DataSource = dt;
            MessageBox.Show("The Searched Data Is Displayed");
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexRow = e.RowIndex;
            DataGridViewRow row = dataGridView4.Rows[indexRow];
            comboBox8.Text = row.Cells[1].Value.ToString();
            comboBox7.Text = row.Cells[2].Value.ToString();
            comboBox6.Text = row.Cells[3].Value.ToString();
            textBox14.Text = row.Cells[4].Value.ToString();

        }

        private void button26_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into StudentAttendance values (@AttendanceId,@StudentId,@AttendanceStatus)", con);
            cmd.Parameters.AddWithValue("@AttendanceId", int.Parse(comboBox11.Text));
            cmd.Parameters.AddWithValue("@StudentId", int.Parse(comboBox10.Text));
            cmd.Parameters.AddWithValue("@AttendanceStatus", comboBox9.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully Inserted");
            comboBox9.ResetText();
            comboBox10.ResetText();
            comboBox11.ResetText();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Update StudentAttendance set AttendanceId=@AttendanceId,StudentId=@StudentId where AttendanceStatus=@AttendanceStatus ", con);
            cmd.Parameters.AddWithValue("@AttendanceId", int.Parse(comboBox11.Text));
            cmd.Parameters.AddWithValue("@StudentId", int.Parse(comboBox10.Text));
            cmd.Parameters.AddWithValue("@AttendanceStatus", comboBox9.Text);
            MessageBox.Show("Successfully Updated");
            comboBox9.ResetText();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            string AttendanceStatus = comboBox9.Text;
            SqlCommand cmd = new SqlCommand("Delete FROM StudentAttendance WHERE AttendanceStatus  = '" + AttendanceStatus + "' ", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully Deleted");
            comboBox9.ResetText();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from StudentAttendance", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView5.DataSource = dt;
        }

        private void button57_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from StudentAttendance where  AttendanceStatus=@AttendanceStatus", con);
            cmd.Parameters.AddWithValue("@AttendanceStatus",comboBox9.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView5.DataSource = dt;
            MessageBox.Show("The Searched Data Is Displayed");
        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int indexRow = e.RowIndex;
            DataGridViewRow row = dataGridView5.Rows[indexRow];
            comboBox11.Text = row.Cells[1].Value.ToString();
            comboBox10.Text = row.Cells[2].Value.ToString();
            comboBox9.Text = row.Cells[3].Value.ToString();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into ClassAttendance values (@AttendanceDate)", con);
            cmd.Parameters.AddWithValue("@AttendanceDate", textBox7.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully Inserted");
            textBox7.Clear();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Update ClassAttendance set where AttendanceDate=@AttendanceDate", con);
            cmd.Parameters.AddWithValue("@AttendanceDate", textBox7.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully Updated");
            textBox7.Clear();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            string AttendanceDate = textBox7.Text;
            SqlCommand cmd = new SqlCommand("Delete FROM ClassAttendance WHERE AttendanceDate  = '" + AttendanceDate + "' ", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully Deleted");
            textBox7.Clear();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from ClassAttendance", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView6.DataSource = dt;
        }

        private void button58_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from ClassAttendance where AttendanceDate=@AttendanceDate", con);
            cmd.Parameters.AddWithValue("@AttendanceDate", textBox7.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView6.DataSource = dt;
            MessageBox.Show("The Searched Data Is Displayed");
        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexRow = e.RowIndex;
            DataGridViewRow row = dataGridView6.Rows[indexRow];
            textBox7.Text = row.Cells[1].Value.ToString();
        }

        private void button41_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into RubricLevel values (@RubricId, @Details,@MeasurementLevel)", con);
            cmd.Parameters.AddWithValue("@RubricId", int.Parse(comboBox5.Text));
            cmd.Parameters.AddWithValue("@Details", textBox10.Text);
            cmd.Parameters.AddWithValue("@MeasurementLevel", int.Parse(textBox16.Text));
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully Inserted");
            comboBox5.ResetText();
            textBox10.Clear();
            textBox16.Clear();

        }

        private void button40_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Update RubricLevel set  Details=@Details,MeasurementLevel=@MeasurementLevel where RubricId=@RubricId", con);
            cmd.Parameters.AddWithValue("@RubricId", int.Parse(comboBox5.Text));
            cmd.Parameters.AddWithValue("@Details", textBox10.Text);
            cmd.Parameters.AddWithValue("@MeasurementLevel", int.Parse(textBox16.Text));
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully Updated");
            comboBox5.ResetText();
            textBox10.Clear();
            textBox16.Clear();
        }

        private void button39_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            string RubricId = comboBox5.Text;
            SqlCommand cmd = new SqlCommand("Delete FROM RubricLevel WHERE RubricId  = '" + RubricId + "' ", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully Deleted");
            comboBox5.ResetText();
        }

        private void button38_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from RubricLevel", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView7.DataSource = dt;
        }

        private void dataGridView7_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexRow = e.RowIndex;
            DataGridViewRow row = dataGridView7.Rows[indexRow];
            comboBox5.Text = row.Cells[1].Value.ToString();
            textBox10.Text = row.Cells[2].Value.ToString();
            textBox16.Text = row.Cells[3].Value.ToString();
        }



        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox27_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }


        private void label48_Click(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        SqlConnection connection = new SqlConnection(@"Data Source= DESKTOP-F7ONIN3;Initial Catalog= ProjectB ;Integrated Security=True");
        private void button60_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage11;
            SqlCommand command = new SqlCommand("Select * from Student", connection);
            SqlDataAdapter d = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            d.Fill(dt);

            reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource source = new ReportDataSource("DataSet1", dt);
            reportViewer1.LocalReport.ReportPath = (@"C:\Users\Hp\Desktop\db2020-cs-129\ProjectB\Student.rdlc");
            reportViewer1.LocalReport.DataSources.Add(source);
            reportViewer1.RefreshReport();

        }

        private void button61_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }

        private void button62_Click(object sender, EventArgs e)

        {
            tabControl1.SelectedTab = tabPage12;
            SqlCommand command = new SqlCommand("Select * from CLO", connection);
            SqlDataAdapter d = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            d.Fill(dt);

            reportViewer2.LocalReport.DataSources.Clear();
            ReportDataSource source = new ReportDataSource("DataSet1", dt);
            reportViewer2.LocalReport.ReportPath = (@"C:\Users\Hp\Desktop\db2020-cs-129\ProjectB\CLO.rdlc");
            reportViewer2.LocalReport.DataSources.Add(source);
            reportViewer2.RefreshReport();
        }

        private void button63_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage13;
            SqlCommand command = new SqlCommand("Select * from Rubric", connection);
            SqlDataAdapter d = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            d.Fill(dt);

            reportViewer3.LocalReport.DataSources.Clear();
            ReportDataSource source = new ReportDataSource("DataSet1", dt);
            reportViewer3.LocalReport.ReportPath = (@"C:\Users\Hp\Desktop\db2020-cs-129\ProjectB\Rubric.rdlc");
            reportViewer3.LocalReport.DataSources.Add(source);
            reportViewer3.RefreshReport();
        }
    }
}



