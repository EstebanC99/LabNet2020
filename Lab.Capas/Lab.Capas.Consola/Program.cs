using Lab.Capas.Logic;
using Lab.Capas.Logic.Extensions;
using Lab.Capas.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Capas.Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcion = Menu();
            do {
                switch (opcion)
                {
                    case 1:
                        VerTerritorios(new TerritoriesLogic());
                        break;
                    case 2:
                        VerRegiones(new RegionLogic());
                        break;
                    case 3:
                        VerEmpleados(new EmployeeLogic());
                        break;
                    case 4:
                        BuscarTerritorios(new TerritoriesLogic());
                        break;
                    case 5:
                        BuscarEmpleados(new EmployeeLogic());
                        break;
                    case 6:
                        ABMRegion();
                        break;
                    case 7:
                        ABMTerritorio();
                        break;
                    case 8:

                        break;
                    default:
                        break;
                }
                Console.ReadKey();
                Console.Clear();
                opcion = Menu();
            } while (opcion != 0);
        }

        public static int Menu()
        {
            Console.WriteLine($"Ingrese una opcion: \n 1) Ver todos los territorios" +
                $"\n 2) Ver todas las regiones \n 3) Ver todos los empleados" +
                $"\n 4) Buscar territorio por descripcion \n 5) Buscar empleado por nombre" +
                $"\n 6) ABM regiones \n 7) ABM territorios \n 0) Salir");
            int op = int.Parse(Console.ReadLine());
            Console.Clear();
            return op;
        }




        #region Regiones
        static void VerRegiones(RegionLogic regionLogic)
        {
            foreach (var region in regionLogic.GetAll())
            {
                Console.WriteLine($"{region.RegionID} --> {region.RegionDescription}");
            }
        }

        public static void ABMRegion()
        {
            Console.WriteLine($"Tablas diponibles sobre las cuales operar:" +
                $"\n A) Alta \n B) Baja \n M) Modificacion");
            char tabla = Console.ReadLine().ToLower()[0];
            switch (tabla)
            {
                case 'a':
                    CargarRegion(new RegionLogic());
                    break;
                case 'b':
                    BorrarRegion(new RegionLogic());
                    break;
                case 'm':
                    ActualizarRegion(new RegionLogic());
                    break;
                default:
                    break;
            }
        }

        #region ABM
        static void CargarRegion(RegionLogic regionLogic)
        {
            Console.Write($"Descripcion de la nueva region: ");
            Region newRegion = new Region();
            newRegion.RegionDescription = Console.ReadLine();
            try
            {
                regionLogic.Insert(newRegion);
                Console.WriteLine("Operacion exitosa!");
                regionLogic.GetAll();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Fin de la operacion");
            }
            
        }

        static void BorrarRegion(RegionLogic regionLogic)
        {
            VerRegiones(regionLogic);
            Console.Write($"ID de la region a borrar: ");
            try
            {
                int borrarID = int.Parse(Console.ReadLine());
                regionLogic.Delete(borrarID);
                Console.WriteLine("Operacion exitosa!");
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message("Solo se permiten numeros"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Fin de la operacion");
            }
            


        }

        static void ActualizarRegion(RegionLogic regionLogic)
        {
            VerRegiones(regionLogic);
            Console.Write($"Ingrese ID de region a actualizar:");
            try
            {
                Region actualizadaRegion = regionLogic.GetOne(int.Parse(Console.ReadLine()));
                Console.Write("Descripcion: ");
                actualizadaRegion.RegionDescription = Console.ReadLine();
                regionLogic.Update(actualizadaRegion);
                Console.WriteLine("Actualizacion exitosa!");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Fin de la operacion!");
            }
        }
        #endregion

        #endregion

        #region Territorios
        static void VerTerritorios(TerritoriesLogic territoriesLogic)
        {
            foreach (var territory in territoriesLogic.GetAll())
            {
                Console.WriteLine($"{territory.TerritoryID})--> {territory.TerritoryDescription} ");
            }
        }

        static void BuscarTerritorios(TerritoriesLogic territoriesLogic)
        {
            try
            {
                var territory = territoriesLogic.GetTerritoryDescrip(Console.ReadLine());
                Console.WriteLine(territory.TerritoryID);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        static void ABMTerritorio()
        {
            Console.WriteLine($"Elija operacion:" +
                $"\n A) Alta \n B) Baja \n M) Modificacion");
            char tabla = Console.ReadLine().ToLower()[0];
            switch (tabla)
            {
                case 'a':
                    CargarTerritorio(new TerritoriesLogic());
                    break;
                case 'b':
                    BorrarTerritorio(new TerritoriesLogic());
                    break;
                case 'm':
                    ActualizarTerritorio(new TerritoriesLogic());
                    break;
                default:
                    Console.WriteLine("Saliendo");
                    System.Threading.Thread.Sleep(1000);
                    break;
            }
        }

        #region ABM

        static void CargarTerritorio(TerritoriesLogic territoriesLogic)
        {
            Territories newTerritory = new Territories();
            try
            {
                Console.Write($"Clave: ");
                newTerritory.TerritoryID = Console.ReadLine();
                Console.Write($"Descripcion del nuevo territorio: ");
                newTerritory.TerritoryDescription = Console.ReadLine();
                Console.Write($"ID Region: ");
                newTerritory.RegionID = int.Parse(Console.ReadLine());
                territoriesLogic.Insert(newTerritory);
                Console.WriteLine("Operacion exitosa!");
                territoriesLogic.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Fin de la operacion");
            }

        }

        static void BorrarTerritorio(TerritoriesLogic territoriesLogic)
        {
            VerTerritorios(territoriesLogic);
            Console.Write($"ID del territorio a borrar: ");
            try
            {
                string borrarID = Console.ReadLine();
                territoriesLogic.Delete(borrarID);
                Console.WriteLine("Operacion exitosa!");
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message("Verifique la clave"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Fin de la operacion");
            }



        }

        static void ActualizarTerritorio(TerritoriesLogic territoriesLogic)
        {
            VerTerritorios(territoriesLogic);
            Console.Write($"Ingrese ID del territorio a actualizar:");
            try
            {
                Territories actualizadaEntity = territoriesLogic.GetOne(Console.ReadLine());
                Console.Write("Descripcion: ");
                actualizadaEntity.TerritoryDescription = Console.ReadLine();
                territoriesLogic.Update(actualizadaEntity);
                Console.WriteLine("Actualizacion exitosa!");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Fin de la operacion!");
            }
        }
        #endregion
        #endregion

        #region Empleados
        static void VerEmpleados(EmployeeLogic employeeLogic)
        {
            foreach (var employee in employeeLogic.GetAll())
            {
                Console.WriteLine($"{employee.EmployeeID} --> {employee.FirstName}");
            }
        }

        static void BuscarEmpleados(EmployeeLogic employeeLogic)
        {
            try
            {
                var employee = employeeLogic.GetOne(Console.ReadLine());
                Console.WriteLine(employee.EmployeeID);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion
    }
}
