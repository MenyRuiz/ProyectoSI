-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 18-07-2019 a las 20:40:53
-- Versión del servidor: 10.3.16-MariaDB
-- Versión de PHP: 7.3.7

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `controli`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `productos`
--

CREATE TABLE `productos` (
  `id_producto` int(100) NOT NULL,
  `nombre` varchar(100) NOT NULL,
  `precio` double NOT NULL,
  `cantidad` int(100) NOT NULL,
  `total` double NOT NULL,
  `concepto` varchar(100) NOT NULL,
  `fecha` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `productos`
--

INSERT INTO `productos` (`id_producto`, `nombre`, `precio`, `cantidad`, `total`, `concepto`, `fecha`) VALUES
(18, 'Pan', 10, 40, 400, 'Produccion', '2019/7/17'),
(19, 'Juan', 30, 12, 360, 'Donacion', '2019/7/17'),
(21, 'Arroz', 13, 20, 260, 'Produccion', '2019/7/17'),
(22, 'jjaja', 2, 54, 108, 'Produccion', '2019/7/17'),
(23, 'non', 5, 5, 25, 'Donacion', '2019/7/17'),
(24, 'Pan', 10, 100, 1000, 'Produccion', '2019/7/17'),
(25, 'Pan', 10, 50, 500, 'Produccion', '2019/7/17');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuarios`
--

CREATE TABLE `usuarios` (
  `id_usuario` int(100) NOT NULL,
  `Nombre` varchar(100) NOT NULL,
  `Usuario` varchar(100) NOT NULL,
  `Contraseña` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `usuarios`
--

INSERT INTO `usuarios` (`id_usuario`, `Nombre`, `Usuario`, `Contraseña`) VALUES
(1, 'Juan Manuel Rincon Ruiz', 'Meny', '123'),
(2, 'Nombre', 'Usuario', 'Contraseña'),
(3, 'Manuel', 'Rincon', 'Ruiz'),
(4, 'nom', 'mmm', 'nnn'),
(5, 'Nombre', 'Usuario', 'Contraseña'),
(6, 'ssss', 'ssss', 'ssss'),
(7, 'ddd', 'ddd', 'ddd'),
(8, 'Nombre', 'Usuario', 'Contraseña'),
(9, 'NOMBRE', 'USUARIO', 'CONTRASEÑA'),
(10, 'Nombre', 'Usuario', 'Contraseña'),
(11, 'Nombre', 'Usuario', 'Contraseña'),
(12, 'NOMBRE', 'USUARIO', 'CONTRASEÑA');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `productos`
--
ALTER TABLE `productos`
  ADD PRIMARY KEY (`id_producto`);

--
-- Indices de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  ADD PRIMARY KEY (`id_usuario`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `productos`
--
ALTER TABLE `productos`
  MODIFY `id_producto` int(100) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=26;

--
-- AUTO_INCREMENT de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  MODIFY `id_usuario` int(100) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
