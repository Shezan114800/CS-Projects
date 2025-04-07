package ui;


import java.awt.*;
import java.awt.event.ActionListener;
import java.awt.event.ActionEvent;
import javax.swing.*;

public class StudentHome extends JFrame {
	
    JLabel Name;
    JLabel Id;
    JLabel Phonenumber;
    JLabel Address;
    JLabel Cgpa;
	
	
    JButton logout;
	
public  StudentHome (){
	
      this.setTitle("STUDENT HOME ");
      this.setBounds(0,0,1500,750);
	  
	   setLayout(null);
       getContentPane().setBackground(Color.BLACK);
	   
	    JLabel title = new JLabel("STUDENT INFORMATION");
        add(title);
        title.setBounds(520,50,550,30);
        title.setForeground(Color.YELLOW);
        title.setBackground(Color.YELLOW);
        title.setFont(new Font("Tahoma",Font.BOLD,30));
		
		
	   Name = new JLabel("STUDENT NAME:");
       Name.setBounds(500,100,300,70);
       Name.setForeground(Color.WHITE);
       Name.setBackground(Color.WHITE);
       add(Name);
	   
	   Id = new JLabel("Student ID:");
       Id.setBounds(500,150,300,70);
       Id.setForeground(Color.WHITE);
       Id.setBackground(Color.WHITE);
       add(Id);
	   
	      
       Phonenumber= new JLabel("Phone Number:");
        Phonenumber.setBounds(500,200,300,70);
        Phonenumber.setForeground(Color.WHITE);
        Phonenumber.setBackground(Color.WHITE);
       add( Phonenumber);
	   
	   Address = new JLabel("Address:");
       Address.setBounds(500,400,300,70);
       Address.setForeground(Color.WHITE);
       Address.setBackground(Color.WHITE);
       add(Address);
	   
	   Cgpa = new JLabel("Cgpa:");
       Cgpa.setBounds(500,250,250,70);
       Cgpa.setForeground(Color.WHITE);
       Cgpa.setBackground(Color.WHITE);
       add(Cgpa);
	   
	   logout=new JButton(" Logout");
       logout.setBounds(990,10,90,35);
       logout.setForeground(Color.WHITE);
       logout.setBackground(Color.RED);
       add(logout);
	   
	   logout.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent ae) {
                dispose();
              StudentLogin sl= new StudentLogin();
               sl.setVisible(true);
            }
	 });
}
	   
	   	public static void main(String[] args) {
				
	        StudentHome sh=new StudentHome();
	        sh.setVisible(true);
	}
}
	   
	   
       
	