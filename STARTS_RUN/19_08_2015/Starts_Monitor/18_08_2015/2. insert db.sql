insert into AllCode
values('CUSTOMER','TYPE',1,'Cá nhân',0);

insert into AllCode
values('CUSTOMER','TYPE',0,'Tổ chức',1);

update Functions set name = 'Khách hàng',objname = 'frmCustomer_Display'
where id = 'renter';

insert into Functions(name,id,PRID,lev,last,status,objname)
values('Traces_Log','rpTraces','ad',1,'Y','A','frmtracedisplay');