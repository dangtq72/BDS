ALTER TABLE Fees_Revenue
ADD Fee_Vnd numeric(18,0);

update Fees_Revenue set Fee_Vnd = 0;
update Fees_Revenue set Fee_Vnd = Fee_Expected where Currency = 1 and Object_Type =  1;