using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garage_2.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Garage_2
{

    public enum VehicleType
    {
        Airplane,
        Boat,
        Bus,
        Car,
        Motorcycle,
    }

    public const var vehicleParkingSize=   
              new Dictionary<VehicleType, float>(){ 
                                  {VehicleType.Airplane, 3}, 
                                  {VehicleType.Boat, 3}, 
                                  {VehicleType.Bus, 2},
                                  {VehicleType.Car, 1},
                                  {VehicleType.Motorcycle, (1/3)},
              };  

    public const int Garage_ParkingCap = 50;
    
    public var parkingSpaces= new ParkingSpace[Garage_ParkingCap];




    public int GetNextAvailableSpace(VehicleType? vehicleType,int? posParkingSpace ) {
        if (posParkingSpace == null) posParkingSpace=0;
         var parkingSizeVehicle= vehicleParkingSize(VehicleType) ?? 1;

        for (int i = posParkingSpace; i <= parkingSpaces.lenght-parkingSizeVehicle ; i++)
			{
            var freeSpace=true;
            for (int s = 0; s < parkingSizeVehicle; s++) {
                if (parkingSpaces[i+s] != null) freeSpace=false;
			}
            if (freeSpace) return i;
		}
    }

    public int  GetNrOfAvailableSpace(VehicleType? vehicleType) {
        int? posParkingSpace=0;
        var nrOfParkingSpace=0;
        while (posParkingSpace != null) {
            posParkingSpace=GetNextAvailableSpace(vehicleType,posParkingSpace);
            if (posParkingSpace != null) nrOfParkingSpace++;
        }
        return nrOfParkingSpace;
    }

 

    public void Park(ParkedVehicleId? id,int? posParkingSpace, bool? unPark){
        var parkedVehicle = GetParkedVehicle(ParkedVehicleId);
        var parkingSizeVehicle= vehicleParkingSize(parkedVehicle.VehicleType) ?? 1;

        for (int s = 0; s < parkingSizeVehicle; s++) {
            parkingSpaces[posParkingSpace+s]=(unPark)? null: ParkedVehicleId;
        }
    }

    public void UnPark(ParkedVehicleId id){
        int? posParkingSpace=null;
        for (int i = 0; i <= parkingSpaces.lenght-parkingSizeVehicle ; i++) {
            if (parkingSpaces[i] == ParkedVehicleId){
                posParkingSpace=i;
                continue;
            }
        }
        if (posParkingSpace) Park(ParkedVehicleId,posParkingSpace,true);
    }

    public ParkedVehicle GetParkedVehicle(ParkedVehicleId id){
            var parkedVehicle = await _context.ParkedVehicle
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parkedVehicle != null) return parkedVehicle;
    }




    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<Garage_2Context>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("Garage_2Context")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=ParkedVehicles}/{action=Index}/{id?}");
            });
        }
    }
}
