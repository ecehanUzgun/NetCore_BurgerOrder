*** RoadMap
Identity, Cookie, Session kullanýlacak.

++ appsettings.json ConnectionString, Default Connection
++ Entities oluþtur
++ Context oluþtur
++ Program.cs 
++ Migration ekle, database oluþtur
++ ViewModel oluþtur
++ Register ->Controller ->View
++ Login ->Controller ->View (RememberMe ekle)
++ Area Template
-- Admin giriþ yaptýðýnda Dashboard'a yönlendirsin
++ Dashboard Update Create
++ Role CRUD (Admin yapabilir)
-- User CRUD (Admin yapabilir)	*****
-- Admin rolündeki kullanýcý giriþ yaptýðýnda Adminlte ekraný açýlsýn.

-- Home/Index -> Hamburger menu , Alýþveriþi tamamla butonuna týklayýnca login, hesap yoksa register

++ Dashboard/Role/Index -> Roller listenelenecek tablo halinde CRUD iþlemleri her biri için button
++ Create Role, description ekle

++ Area'da Logout, Account çalýþmýyor!!!!! -> Çözüldü _Layout'da area="" tanýmlayarak
-- Delete for Role and User does not work!!!!

--ADMINLTE
--NTIER Architecture

***Session 
--Sipariþi tamamla butonuna týklandýðýnda form açýlacak, açýlan form doldurulduðunda (user) sipariþiniz oluþturuldu .
--Sepet boþ ise sipariþ oluþturulamaz!