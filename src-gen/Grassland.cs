namespace rugby_sim {
	using System;
	using System.Linq;
	using System.Collections.Generic;
	// Pragma and ReSharper disable all warnings for generated code
	#pragma warning disable 162
	#pragma warning disable 219
	#pragma warning disable 169
	[System.Diagnostics.CodeAnalysis.SuppressMessage("ReSharper", "InconsistentNaming")]
	[System.Diagnostics.CodeAnalysis.SuppressMessage("ReSharper", "UnusedParameter.Local")]
	[System.Diagnostics.CodeAnalysis.SuppressMessage("ReSharper", "RedundantNameQualifier")]
	[System.Diagnostics.CodeAnalysis.SuppressMessage("ReSharper", "PossibleInvalidOperationException")]
	[System.Diagnostics.CodeAnalysis.SuppressMessage("ReSharper", "ExpressionIsAlwaysNull")]
	[System.Diagnostics.CodeAnalysis.SuppressMessage("ReSharper", "MemberInitializerValueIgnored")]
	[System.Diagnostics.CodeAnalysis.SuppressMessage("ReSharper", "RedundantCheckBeforeAssignment")]
	public class Grassland : Mars.Components.Layers.AbstractLayer {
		private static readonly Mars.Common.Logging.ILogger _Logger = 
					Mars.Common.Logging.LoggerFactory.GetLogger(typeof(Grassland));
		private readonly System.Random _Random = new System.Random();
		public Mars.Interfaces.Layer.UnregisterAgent _Unregister { get; set; }
		public Mars.Interfaces.Layer.RegisterAgent _Register { get; set; }
		public Mars.Mathematics.SpaceDistanceMetric _DistanceMetric { get; set; } = Mars.Mathematics.SpaceDistanceMetric.Euclidean;
		private int _dimensionX, _dimensionY;
		public int DimensionX() => _dimensionX;
		public int DimensionY() => _dimensionY;
		public System.Collections.Concurrent.ConcurrentDictionary<Mars.Interfaces.Environment.Position, string> 
			_StringGrassland { get; set; }
		public System.Collections.Concurrent.ConcurrentDictionary<Mars.Interfaces.Environment.Position, double> 
			_RealGrassland { get; set; }
		
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public string GetStringValue(int x, int y) => GetStringValue((double)x, y);
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public string GetStringValue(double x, double y) =>
			_StringGrassland.TryGetValue(Mars.Interfaces.Environment.Position.CreatePosition(x, y), out var value) ? value : null;
		
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public int GetIntegerValue(int x, int y) => GetIntegerValue((double)x, y);
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public int GetIntegerValue(double x, double y) =>
					_RealGrassland.TryGetValue(Mars.Interfaces.Environment.Position.CreatePosition(x, y), out var value) ? Convert.ToInt32(value) : 0;
		
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public double GetRealValue(int x, int y) => GetRealValue((double)x, y);
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public double GetRealValue(double x, double y) =>
			_RealGrassland.TryGetValue(Mars.Interfaces.Environment.Position.CreatePosition(x, y), out var value) ? value : 0;
		
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void SetStringValue(int x, int y, string value) => SetStringValue((double)x, y, value);
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void SetStringValue(double x, double y, string value)
		{
			if (value != null)
				_StringGrassland.AddOrUpdate(Mars.Interfaces.Environment.Position.CreatePosition(x, y), value,
					(position, s) => value);
		}
		
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void SetIntegerValue(double x, double y, int value) => SetRealValue(x, y, value);
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void SetIntegerValue(int x, int y, int value) => SetRealValue((double)x, y, value);
		
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void SetRealValue(int x, int y, double value) => SetRealValue((double)x, y, value);
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void SetRealValue(double x, double y, double value)
		{
			if (Math.Abs(value) > 0.000000001)
				_RealGrassland.AddOrUpdate(Mars.Interfaces.Environment.Position.CreatePosition(x, y), value,
					(position, s) => value);
		}
		
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		private void _InitGrid(Mars.Interfaces.Layer.Initialization.TInitData initData)
		{
			if (initData.LayerInitConfig != null && !string.IsNullOrEmpty(initData.LayerInitConfig.File))
			{
				var table = Mars.Common.IO.Csv.CsvReader.MapData(initData.LayerInitConfig.File, null, false);
				
				var xMaxIndex = table.Columns.Count;
				int yMaxIndex = table.Rows.Count - 1;
		
				_dimensionX = table.Columns.Count;
				_dimensionY = table.Rows.Count;
				foreach (System.Data.DataRow tableRow in table.Rows)
				{
					for (int x = 0; x < xMaxIndex; x++)
					{
						var value = tableRow[x].ToString();
						if (double.TryParse(value, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture,
							out var result))
							SetRealValue(x, yMaxIndex, result);
						else
							SetStringValue(x, yMaxIndex, value);
					}
					yMaxIndex --;
				}
			}
		}
		
		public Mars.Components.Environments.SpatialHashEnvironment<AllBlack> _AllBlackEnvironment { get; set; }
		public Mars.Components.Environments.SpatialHashEnvironment<Wallaby> _WallabyEnvironment { get; set; }
		public System.Collections.Generic.IDictionary<System.Guid, AllBlack> _AllBlackAgents { get; set; }
		public System.Collections.Generic.IDictionary<System.Guid, Wallaby> _WallabyAgents { get; set; }
		
		public Grassland _Grassland => this;
		public Grassland grass => this;
		public Grassland (
		double dimensionX = 100, double dimensionY = 100, int cellSize = 1
				) {
			_dimensionX = Convert.ToInt32(dimensionX); _dimensionY = Convert.ToInt32(dimensionY);
			_StringGrassland = new System.Collections.Concurrent.ConcurrentDictionary<Mars.Interfaces.Environment.Position, string>();
			_RealGrassland = new System.Collections.Concurrent.ConcurrentDictionary<Mars.Interfaces.Environment.Position, double>();
		}
		
		public override bool InitLayer(
			Mars.Interfaces.Layer.Initialization.TInitData initData, 
			Mars.Interfaces.Layer.RegisterAgent regHandle, 
			Mars.Interfaces.Layer.UnregisterAgent unregHandle)
		{
			base.InitLayer(initData, regHandle, unregHandle);
			this._Register = regHandle;
			this._Unregister = unregHandle;
			
			_InitGrid(initData);
			this._AllBlackEnvironment = new Mars.Components.Environments.SpatialHashEnvironment<AllBlack>(_dimensionX, _dimensionY, true);
			this._WallabyEnvironment = new Mars.Components.Environments.SpatialHashEnvironment<Wallaby>(_dimensionX, _dimensionY, true);
			
			_AllBlackAgents = Mars.Components.Services.AgentManager.SpawnAgents<AllBlack>(
			initData.AgentInitConfigs.First(config => config.Type == typeof(AllBlack)),
			regHandle, unregHandle, 
			new System.Collections.Generic.List<Mars.Interfaces.Layer.ILayer> { this });
			_WallabyAgents = Mars.Components.Services.AgentManager.SpawnAgents<Wallaby>(
			initData.AgentInitConfigs.First(config => config.Type == typeof(Wallaby)),
			regHandle, unregHandle, 
			new System.Collections.Generic.List<Mars.Interfaces.Layer.ILayer> { this });
			
			return true;
		}
		
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public rugby_sim.AllBlack _SpawnAllBlack(double xcor = 0, double ycor = 0, int freq = 1) {
			var id = System.Guid.NewGuid();
			var agent = new rugby_sim.AllBlack(id, this, _Register, _Unregister,
			_AllBlackEnvironment,
			default(double)
		, 	xcor, ycor, freq);
			_AllBlackAgents.Add(id, agent);
			return agent;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public rugby_sim.Wallaby _SpawnWallaby(double xcor = 0, double ycor = 0, int freq = 1) {
			var id = System.Guid.NewGuid();
			var agent = new rugby_sim.Wallaby(id, this, _Register, _Unregister,
			_WallabyEnvironment,
			default(int)
		, 	xcor, ycor, freq);
			_WallabyAgents.Add(id, agent);
			return agent;
		}
		
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void _KillAllBlack(rugby_sim.AllBlack target, int executionFrequency = 1)
		{
			target._isAlive = false;
			_AllBlackEnvironment.Remove(target);
			_Unregister(this, target, target._executionFrequency);
			_AllBlackAgents.Remove(target.ID);
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void _KillWallaby(rugby_sim.Wallaby target, int executionFrequency = 1)
		{
			target._isAlive = false;
			_WallabyEnvironment.Remove(target);
			_Unregister(this, target, target._executionFrequency);
			_WallabyAgents.Remove(target.ID);
		}
	}
}
