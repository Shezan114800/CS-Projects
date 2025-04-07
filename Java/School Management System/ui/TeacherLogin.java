package ui;

import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import javax.swing.*;

public class TeacherLogin extends JFrame{

    JLabel UserId,UserPassword;
    JTextField UserIdTextField;
    JPasswordField UserPasswordField;
    JButton login, back;
	
	TeacherLogin()
	{
        this.setDefaultCloseOperation(EXIT_ON_CLOSE);
        this.setBounds(100,50,550,350);		
	    this.setTitle("LOGIN");
		
		setLayout(null);
		getContentPane().setBackground(Color.WHITE);

		
		UserId = new JLabel("ID:");
		add(UserId);
        UserId.setBounds(150, 50, 150, 50);
        UserId.setForeground(Color.BLACK);
        UserId.setBackground(Color.BLACK);
		UserId.setVisible(true);
		
		
		UserIdTextField = new JTextField();
		add(UserIdTextField);
        UserIdTextField.setBounds(240, 60, 130, 30);
		UserIdTextField.setVisible(true);
		
		
		UserPassword = new JLabel("PASSWORD: ");
		add(UserPassword);
        UserPassword.setBounds(150, 120, 150, 50);
        UserPassword.setForeground(Color.BLACK);
        UserPassword.setBackground(Color.BLACK);
        UserPassword.setVisible(true);
		
		UserPasswordField = new JPasswordField();
		add(UserPasswordField);
        UserPasswordField.setBounds(240, 130, 130, 30);
		UserPasswordField.setVisible(true);
		
		
        login = new JButton("Login");
		add(login);
        login.setBounds(170,190,90,50);
        login.setForeground(Color.WHITE);
        login.setBackground(Color.BLUE);
        login.setFont(new Font("Tahoma",Font.BOLD,12));
        login.setVisible(true);
		
		back = new JButton ("Back");
		add(back);
        back.setBounds(280,190,90,50);
        back.setForeground(Color.WHITE);
        back.setBackground(Color.RED);
        back.setFont(new Font("Tahoma",Font.BOLD,12));
        back.setVisible(true);

	
        login.addActionListener(new ActionListener() {
        @Override
        public void actionPerformed(ActionEvent ae) 
        {
			String UserId = UserIdTextField.getText();
			String UserPassword = String.valueOf(UserPasswordField.getPassword());

        if(UserId.equals("123") && UserPassword.equals("321") )
         {
                    JOptionPane.showMessageDialog(null, "Congratulations!! The operation done successfully.");
                    dispose();
                    TeacherHome th = new TeacherHome();
                    th.setVisible(true);
          }
	 else
	      {
             JOptionPane.showMessageDialog(null,"Invalid Id and password");
          }
		}
		 
         });
		 
		 back.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent ae) {
                setVisible(false);
                new Welcome().setVisible(true);
            }
            
});

}
	public static void main(String[] args) {
		
		
	TeacherLogin tl=new TeacherLogin();
	tl.setVisible(true);
	}
}

