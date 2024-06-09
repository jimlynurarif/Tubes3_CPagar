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
('1234567890123456', '13intanGdmtn', 'Jakarta', '1990-01-01', 'Laki-Laki', 'O', 'Jl. Merdeka No. 1', 'Islam', 'Belum Menikah', 'Programmer', 'Indonesia'),
('2345678901234567', 'B1nt4n6 Dw1b M4rthen', 'Bandung', '1992-02-02', 'Perempuan', 'A', 'Jl. Sudirman No. 2', 'Kristen', 'Menikah', 'Desainer', 'Indonesia'),
('3456789012345678', 'Bntng Dwb Mrthen', 'Surabaya', '1988-03-03', 'Perempuan', 'B', 'Jl. Thamrin No. 3', 'Hindu', 'Cerai', 'Pengacara', 'Indonesia'),
('4567890123456789', 'b1ntN6 Dw mrthn', 'Medan', '1985-04-04', 'Laki-Laki', 'AB', 'Jl. Gatot Subroto No. 4', 'Buddha', 'Menikah', 'Dokter', 'Indonesia');

INSERT INTO sidik_jari (berkas_citra, nama)
VALUES
('sidiks/1.BMP', 'Bintang Dwi Marthen'),
('sidiks/3.BMP', 'Jane Smith'),
('sidiks/5.BMP', 'Alice Johnson'),
('sidiks/7.BMP', 'Bob Brown');