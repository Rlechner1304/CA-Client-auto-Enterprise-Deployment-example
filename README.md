# Enterprise-Deployment-exampleto use create an ini file that holds your login credentials for the enterprise and each domain  use the format as below.
[myenterprise]
dmhostname=myenterprise.mynetwork.com
user=administrator
password=password
Enterprise=YES

[dm1]
dmhostname=dm1.mynetwork.com
user=administrator
password=p2

[dm2]
dmhostname=dm2.mynetwork.com
user=administrator
password=p2



Currently the script is written to only support local passords.  You can easily edit the function wslogin function to support domain credentials.  you can also 
in that same function save encryped credentails in the ini file and not do the coversion again in the wslogin function.  

If the same credentials work on all the domains you can comment out the section in the buttoncomputer sub to form1.initialize function where it finds then read in the credential file.

The script is written to deploy software procedures wit default settings feel free to modify the functions in clientauto sample module to edit it as needed.

the script does everything serially ad allws for the selction of onw targert and on e package  as a sample it does things in a very specific sequence
1 prompts user for ini file location
2.gets list of all computers on the enterprise
3 once one selcts the machine name of the target computer the script connects to that machins domain and gets  list of all softwarepackages
4 once one select the package the script then offers all the proceures associated with the  selected package
5.the script then promps the script user to enter the job name they want to assig to the sd job
6. the script now create a software job container, the createsan deplyment job and attaches it to the container, then seasls and activates the sd job
7. once the job is created the script then offers the person the option to chek the staus
the user can keep click on the status putton ntil the job fails or finishes.
