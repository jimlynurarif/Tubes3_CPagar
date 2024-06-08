

DROP TABLE IF EXISTS `biodata`;

CREATE TABLE `biodata` (
  `NIK` varchar(16) NOT NULL,
  `nama` varchar(100) DEFAULT NULL,
  `tempat_lahir` varchar(50) DEFAULT NULL,
  `tanggal_lahir` date DEFAULT NULL,
  `jenis_kelamin` TEXT CHECK( jenis_kelamin IN ('Laki-Laki','Perempuan') ) DEFAULT NULL,
  `golongan_darah` varchar(5) DEFAULT NULL,
  `alamat` varchar(255) DEFAULT NULL,
  `agama` varchar(50) DEFAULT NULL,
  `status_perkawinan` TEXT CHECK( status_perkawinan IN ('Belum Menikah','Menikah','Cerai') ) DEFAULT NULL,
  `pekerjaan` varchar(100) DEFAULT NULL,
  `kewarganegaraan` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`NIK`)
);


DROP TABLE IF EXISTS `sidik_jari`;

CREATE TABLE `sidik_jari` (
  `berkas_citra` text,
  `nama` varchar(100) DEFAULT NULL
) ;
