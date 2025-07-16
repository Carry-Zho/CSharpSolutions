//恒温控制
namespace Code_ThermostaticControl
{
    //定义恒温器类-->发布者类
    internal class Thermostat
    {
        public float CurrentTemperature { get; set; }
        public Action<float>? OnTemperatureChange { get; set; }
    }

    //定义加热器类-->订阅者类
    internal class  Heater
    {
        public float Temperature { get; set; } //存储调控温度
        public Heater(float temperature) { Temperature = temperature; }

        //当环境温度低于调控温度时加热器被激活
        public void OnTemperatureChanged(float newTemperature)
        {
            Console.WriteLine($"当前环境温度{newTemperature},调控温度至{Temperature}");
            if (newTemperature < Temperature)
            {
                Console.WriteLine("Heater:On");
            }
            else
            {
                Console.WriteLine("Heater:off");
            }
        }
    }

    //定义冷却器类-->订阅者类
    internal class Cooler
    {
        //存储调控温度
        public float Temperature { get; set; } 
        public Cooler(float temperature) { Temperature = temperature; }

        //当环境温度高于调控温度时冷却器被激活
        public void OnTemperatureChanged(float newTemperature)
        {
            Console.WriteLine($"当前环境温度{newTemperature},调控温度至{Temperature}");
            if (newTemperature > Temperature)
            {
                Console.WriteLine($"Cooler:On");
            }
            else
            {
                Console.WriteLine($"Cooler:off");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //创建恒温器对象
            Thermostat thermostat = new Thermostat();

            //创建加热器对象
            Heater heater = new Heater(60.0f);
            //创建冷却器对象
            Cooler cooler = new Cooler(80.0f);

            string? temperature;

            //注册订阅者
            thermostat.OnTemperatureChange += heater.OnTemperatureChanged;
            thermostat.OnTemperatureChange += cooler.OnTemperatureChanged;

            Console.WriteLine("请输入环境温度：");
            temperature = Console.ReadLine();

            thermostat.CurrentTemperature = float.Parse(temperature ?? "0");

            //触发温控事件
            thermostat.OnTemperatureChange?.Invoke(thermostat.CurrentTemperature);

            //加热器取消订阅事件
            thermostat.OnTemperatureChange -= heater.OnTemperatureChanged;

            //触发温控事件
            Console.WriteLine("加热器取消订阅事件后，重新触发温控事件。");
            thermostat.OnTemperatureChange?.Invoke(thermostat.CurrentTemperature);

        }
    }
}
