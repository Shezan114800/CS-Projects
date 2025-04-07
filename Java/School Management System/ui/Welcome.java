package ui;

import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import javax.swing.*;

class Welcome extends JFrame{

  JButton Teacher,Student;
  
  public Welcome()
	{   
		
		this.setTitle("Welcome To Our School");
               this.setBounds(0,0,1500,750);	
		
				setLayout(null);
				getContentPane().setBackground(Color.BLACK);
				
                this.setBackground(Color.YELLOW);
                JLabel title = new JLabel("Welcome To Our School");
                add(title);
                title.setBounds(450,60,550,30);
                title.setForeground(Color.YELLOW);
                title.setBackground(Color.YELLOW);
                title.setFont(new Font("Calibri",Font.BOLD,40));
		
                Teacher=new JButton("TEACHER");
				add(Teacher);
		        Teacher.setBounds(500,150,195,60);
                Teacher.setForeground(Color.WHITE);
                Teacher.setBackground(Color.GRAY);
                Teacher.setFont(new Font("Tahoma",Font.BOLD,12));
				
		   
                Student =new JButton("STUDENT");
				add(Student);
		        Student.setBounds(500,250,195,60);
                Student.setForeground(Color.WHITE);
                Student.setBackground(Color.GRAY);
                Student.setFont(new Font("Tahoma",Font.BOLD,12));
				
				
		    Teacher.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent ae) 
            {
				dispose();
              TeacherLogin tl= new TeacherLogin();
                tl.setVisible(true);
            }
       });
	   
	   	    Student.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent ae) 
            {
				dispose();
              StudentLogin sl= new StudentLogin();
                sl.setVisible(true);
            }
       });

}
		
		public static void main(String[] args) {
				
	        Welcome w=new Welcome();
	        w.setVisible(true);
	}
}



               
