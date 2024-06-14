DROP TABLE IF EXISTS `biodata`;

CREATE TABLE biodata (
  NIK varchar(16) NOT NULL,
  nama varchar(100) DEFAULT NULL,
  tempat_lahir varchar(50) DEFAULT NULL,
  tanggal_lahir date DEFAULT NULL,
  jenis_kelamin TEXT CHECK( jenis_kelamin IN ('Laki-Laki','Perempuan') ) DEFAULT NULL,
  golongan_darah varchar(5) DEFAULT NULL,
  alamat varchar(255) DEFAULT NULL,
  agama varchar(50) DEFAULT NULL,
  status_perkawinan TEXT CHECK( status_perkawinan IN ('Belum Menikah','Menikah','Cerai') ) DEFAULT NULL,
  pekerjaan varchar(100) DEFAULT NULL,
  kewarganegaraan varchar(50) DEFAULT NULL,
  PRIMARY KEY (`NIK`)
);


DROP TABLE IF EXISTS `sidik_jari`;

CREATE TABLE sidik_jari (
  berkas_citra text,
  nama varchar(100) DEFAULT NULL
) ;

INSERT INTO biodata (NIK, nama, tempat_lahir, tanggal_lahir, jenis_kelamin, golongan_darah, alamat, agama, status_perkawinan, pekerjaan, kewarganegaraan)
VALUES
('3303011125810774','b1nTN6 dw mrthen','Port Amanda','1949-09-20','Laki-Laki','B','6035 Kimberly Village Apt. 899\nNorth Lindsayport, DC 70968','Katolik','Belum Menikah','Perawat','Fiji'),
('3303022304577991','hziq aBYYu MhdY','Brownport','2019-07-18','Laki-Laki','AB','Unit 2309 Box 6965\nDPO AA 23291','Konghucu','Cerai','Akuntan','Grenada'),
('3303027429445897','B3rn4rdu5 w1ll50N','South Steven','1936-04-21','Laki-Laki','B','30710 Myers Avenue Apt. 213\nRyanland, NE 94224','Islam','Cerai','Dokter','Senegal'),
('3303028343408496','alx sNdr','North Carlosborough','1998-06-13','Laki-Laki','O','5203 Kimberly Roads\nHortonborough, KY 76544','Katolik','Menikah','Chef','Vanuatu'),
('3303038256625159','mOHaMmad rIfQi farhaNsyah','Shepherdborough','1975-04-05','Laki-Laki','O','8600 Lane Gardens\nWest Jennifer, UT 47682','Hindu','Belum Menikah','Ahli IT','Singapore'),
('3303047128796042','fr5ka 2khraLTV4 r5KNd','New Jonathanville','2013-06-06','Perempuan','AB','8703 Johnson Pass Suite 000\nLaurabury, NM 96887','Islam','Cerai','Guru','South Georgia and the South Sandwich Islands'),
('3303055847921779','slthn D2Ky 4LFr0','Lake Stephentown','2011-04-10','Laki-Laki','A','074 Michael Mews Suite 366\nWest Charlesbury, MN 89080','Kristen','Cerai','Arsitek','Chile'),
('3303072755543498','Mchl Ln Ptr Widh','Brockton','1977-01-15','Laki-Laki','AB','86993 Taylor Creek Apt. 418\nRogersland, FL 99643','Katolik','Menikah','Insinyur','Libyan Arab Jamahiriya'),
('3303079689599219','Judh S4nt5','Tammymouth','1984-04-23','Laki-Laki','AB','738 Booker Drive Apt. 037\nEast Vanessa, DC 66121','Kristen','Belum Menikah','Polisi','Philippines'),
('3303092161641780','Nugrah4 Pr1y4 Utam4','South Christina','1948-10-17','Laki-Laki','A','964 Michelle Way Apt. 126\nSouth Sarah, KS 19385','Budha','Belum Menikah','Pengacara','Guam'),
('3303058017706505','R0NLd1 mn1r', 'Morganside', '2002-04-16', 'Laki-Laki', 'A', 'Unit 3883 Box 9413\nDPO AA 54492', 'Katolik', 'Menikah', 'Insinyur', 'Afghanistan'),
('3303036053258590','d4ftar 1rk 651h', 'South Nicole', '2023-02-24', 'Laki-Laki', 'AB', '1985 Andrew Estates Suite 737\nPort Melissaborough, WV 85000', 'Budha', 'Belum Menikah', 'Pilot Drone', 'Bouvet Island (Bouvetoya)'),
('3303010188758202','n1g3L s4HL', 'Kevinview', '1969-12-01', 'Laki-Laki', 'O', '509 Patrick Radial Suite 840\nNew Donaldbury, WI 18058', 'Budha', 'Cerai', 'Perancang Busana', 'Guam'),
('3303060312247709','Ayo Jin IRK', 'North Jamesside', '1948-04-23', 'Laki-Laki', 'A', 'USNV Turner\nFPO AE 92630', 'Katolik', 'Belum Menikah', 'Ahli Fisika', 'Cocos (Keeling) Islands');

INSERT INTO sidik_jari (berkas_citra, nama)
VALUES

('sidiks\55__M_Left_index_finger.bmp','Rila Mandala'),
('sidiks\55__M_Left_little_finger.bmp','Bintang Dwi Marthen'),
('sidiks\55__M_Left_middle_finger.bmp','Bintang Dwi Marthen'),
('sidiks\55__M_Left_ring_finger.bmp','Bintang Dwi Marthen'),
('sidiks\55__M_Left_thumb_finger.bmp','Bintang Dwi Marthen'),
('sidiks\55__M_Right_index_finger.bmp','Bintang Dwi Marthen'),
('sidiks\55__M_Right_middle_finger.bmp','Bintang Dwi Marthen'),
('sidiks\55__M_Right_ring_finger.bmp','Bintang Dwi Marthen'),
('sidiks\55__M_Right_thumb_finger.bmp','Bintang Dwi Marthen'),

('sidiks\81__F_Right_index_finger.bmp','Haziq Abiyyu Mahdy'),
('sidiks\81__F_Right_little_finger.bmp','Haziq Abiyyu Mahdy'),
('sidiks\81__F_Right_middle_finger.bmp','Haziq Abiyyu Mahdy'),
('sidiks\81__F_Right_thumb_finger.bmp','Haziq Abiyyu Mahdy'),

('sidiks\82__M_Left_index_finger.bmp','Bernardus Willson'),
('sidiks\82__M_Left_little_finger.bmp','Bernardus Willson'),
('sidiks\82__M_Left_middle_finger.bmp','Bernardus Willson'),
('sidiks\82__M_Left_ring_finger.bmp','Bernardus Willson'),
('sidiks\82__M_Left_thumb_finger.bmp','Bernardus Willson'),
('sidiks\82__M_Right_index_finger.bmp','Bernardus Willson'),
('sidiks\82__M_Right_little_finger.bmp','Bernardus Willson'),
('sidiks\82__M_Right_ring_finger.bmp','Bernardus Willson'),
('sidiks\82__M_Right_thumb_finger.bmp','Bernardus Willson'),

('sidiks\97__M_Left_little_finger.bmp','Alex Sander'),
('sidiks\97__M_Left_middle_finger.bmp','Alex Sander'),
('sidiks\97__M_Left_ring_finger.bmp','Alex Sander'),
('sidiks\97__M_Right_index_finger.bmp','Alex Sander'),
('sidiks\97__M_Right_little_finger.bmp','Alex Sander'),
('sidiks\97__M_Right_middle_finger.bmp','Alex Sander'),
('sidiks\97__M_Right_ring_finger.bmp','Alex Sander'),
('sidiks\97__M_Right_thumb_finger.bmp','Alex Sander'),

('sidiks\98__M_Left_index_finger.bmp','Mohammad Rifqi Farhansyah'),
('sidiks\98__M_Left_little_finger.bmp','Mohammad Rifqi Farhansyah'),
('sidiks\98__M_Left_middle_finger.bmp','Mohammad Rifqi Farhansyah'),
('sidiks\98__M_Left_thumb_finger.bmp','Mohammad Rifqi Farhansyah'),
('sidiks\98__M_Right_index_finger.bmp','Mohammad Rifqi Farhansyah'),
('sidiks\98__M_Right_little_finger.bmp','Mohammad Rifqi Farhansyah'),
('sidiks\98__M_Right_middle_finger.bmp','Mohammad Rifqi Farhansyah'),
('sidiks\98__M_Right_ring_finger.bmp','Mohammad Rifqi Farhansyah'),
('sidiks\98__M_Right_thumb_finger.bmp','Mohammad Rifqi Farhansyah'),

('sidiks\99__M_Left_index_finger.bmp','Fariska Zakhralativa Ruskanda'),
('sidiks\99__M_Left_little_finger.bmp','Fariska Zakhralativa Ruskanda'),
('sidiks\99__M_Left_middle_finger.bmp','Fariska Zakhralativa Ruskanda'),
('sidiks\99__M_Left_ring_finger.bmp','Fariska Zakhralativa Ruskanda'),
('sidiks\99__M_Left_thumb_finger.bmp','Fariska Zakhralativa Ruskanda'),
('sidiks\99__M_Right_index_finger.bmp','Fariska Zakhralativa Ruskanda'),
('sidiks\99__M_Right_little_finger.bmp','Fariska Zakhralativa Ruskanda'),
('sidiks\99__M_Right_middle_finger.bmp','Fariska Zakhralativa Ruskanda'),
('sidiks\99__M_Right_ring_finger.bmp','Fariska Zakhralativa Ruskanda'),
('sidiks\99__M_Right_thumb_finger.bmp','Fariska Zakhralativa Ruskanda'),

('sidiks\100__M_Right_ring_finger.bmp','Sulthan Dzaky Alfaro'),
('sidiks\100__M_Right_ring_finger_CR.bmp','Sulthan Dzaky Alfaro'),
('sidiks\100__M_Right_ring_finger_Obl.bmp','Sulthan Dzaky Alfaro'),
('sidiks\100__M_Right_ring_finger_Zcut.bmp','Sulthan Dzaky Alfaro'),

('sidiks\102__M_Left_little_finger.bmp','Michael Leon Putra Widhi'),
('sidiks\102__M_Left_little_finger_CR.bmp','Michael Leon Putra Widhi'),
('sidiks\102__M_Left_little_finger_Obl.bmp','Michael Leon Putra Widhi'),
('sidiks\102__M_Left_little_finger_Zcut.bmp','Michael Leon Putra Widhi'),

('sidiks\103__F_Left_ring_finger.bmp','Judhi Santoso'),
('sidiks\103__F_Left_thumb_finger.bmp','Judhi Santoso'),
('sidiks\103__F_Left_thumb_finger_Obl.bmp','Judhi Santoso'),
('sidiks\103__F_Right_index_finger.bmp','Judhi Santoso'),
('sidiks\103__F_Right_index_finger_CR.bmp','Judhi Santoso'),
('sidiks\103__F_Right_index_finger_Obl.bmp','Judhi Santoso'),

('sidiks\564__M_Right_ring_finger.bmp','Rinaldi Munir'),
('sidiks\564__M_Right_thumb_finger.bmp','Rinaldi Munir'),

('sidiks\565__M_Left_index_finger.bmp','Nugraha Priya Utama'),
('sidiks\565__M_Left_little_finger.bmp','Nugraha Priya Utama'),
('sidiks\565__M_Left_middle_finger.bmp','Nugraha Priya Utama'),
('sidiks\565__M_Left_ring_finger.bmp','Nugraha Priya Utama'),
('sidiks\565__M_Left_thumb_finger.bmp','Nugraha Priya Utama'),
('sidiks\565__M_Right_index_finger.bmp','Nugraha Priya Utama'),
('sidiks\565__M_Right_little_finger.bmp','Nugraha Priya Utama'),
('sidiks\565__M_Right_middle_finger.bmp','Nugraha Priya Utama'),
('sidiks\565__M_Right_ring_finger.bmp','Nugraha Priya Utama'),
('sidiks\565__M_Right_thumb_finger.bmp','Nugraha Priya Utama'),

('sidiks\566__M_Left_index_finger.bmp','Daftar IRK Gasih'),
('sidiks\566__M_Left_little_finger.bmp','Daftar IRK Gasih'),
('sidiks\566__M_Left_middle_finger.bmp','Daftar IRK Gasih'),
('sidiks\566__M_Left_ring_finger.bmp','Daftar IRK Gasih'),
('sidiks\566__M_Left_thumb_finger.bmp','Daftar IRK Gasih'),
('sidiks\566__M_Right_little_finger.bmp','Daftar IRK Gasih'),

('sidiks\568__M_Left_index_finger.bmp','Nigel Sahl'),
('sidiks\568__M_Left_little_finger.bmp','Nigel Sahl'),
('sidiks\568__M_Left_middle_finger.bmp','Nigel Sahl'),
('sidiks\568__M_Left_thumb_finger.bmp','Nigel Sahl'),
('sidiks\568__M_Right_index_finger.bmp','Nigel Sahl'),
('sidiks\568__M_Right_little_finger.bmp','Nigel Sahl'),
('sidiks\568__M_Right_middle_finger.bmp','Nigel Sahl'),
('sidiks\568__M_Right_ring_finger.bmp','Nigel Sahl'),
('sidiks\568__M_Right_thumb_finger.bmp','Nigel Sahl'),

('sidiks\569__M_Left_index_finger.bmp','Ayo Join IRK'),
('sidiks\569__M_Left_little_finger.bmp','Ayo Join IRK'),
('sidiks\569__M_Left_middle_finger.bmp','Ayo Join IRK'),
('sidiks\569__M_Left_ring_finger.bmp','Ayo Join IRK'),
('sidiks\569__M_Left_thumb_finger.bmp','Ayo Join IRK'),
('sidiks\569__M_Right_index_finger.bmp','Ayo Join IRK'),
('sidiks\569__M_Right_little_finger.bmp','Ayo Join IRK'),
('sidiks\569__M_Right_middle_finger.bmp','Ayo Join IRK'),
('sidiks\569__M_Right_ring_finger.bmp','Ayo Join IRK'),
('sidiks\569__M_Right_thumb_finger.bmp','Ayo Join IRK');