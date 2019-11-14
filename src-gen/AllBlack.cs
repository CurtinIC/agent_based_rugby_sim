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
	public class AllBlack : Mars.Interfaces.Agent.IMarsDslAgent {
		private static readonly Mars.Common.Logging.ILogger _Logger = 
					Mars.Common.Logging.LoggerFactory.GetLogger(typeof(AllBlack));
		private readonly System.Random _Random = new System.Random();
		private string __Rule
			 = "";
		public string Rule { 
			get { return __Rule; }
			set{
				if(__Rule != value) __Rule = value;
			}
		}
		private double __speed
			 = default(double);
		public double speed { 
			get { return __speed; }
			set{
				if(System.Math.Abs(__speed - value) > 0.0000001) __speed = value;
			}
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void Run() 
		{
			{
			rugby_sim.Wallaby nearestWallaby = new Func<rugby_sim.Wallaby>(() => {
				Func<rugby_sim.Wallaby, bool> _predicate60_747 = null;
				Func<rugby_sim.Wallaby, bool> _predicateMod60_747 = new Func<rugby_sim.Wallaby, bool>(_it => 
				{
					if (_it?.ID == this.ID)
					{
						return false;
					} else if (_predicate60_747 != null)
					{
						return _predicate60_747.Invoke(_it);
					} else return true;
				});
				
				const int _range60_747 = -1;
				var _source60_747 = this.Position;
				
				return _Grassland._WallabyEnvironment.Explore(_source60_747, _range60_747, 1, _predicateMod60_747)?.FirstOrDefault();
			}).Invoke();
			if(nearestWallaby.GetHasBall()
			) {
							{
							new System.Func<Tuple<double,double>>(() => {
								
								var _speed63_803 = 1 * speed
							;
								
								var _entity63_803 = this;
								
								Func<double[], bool> _predicate63_803 = null;
								
								var _target63_803 = nearestWallaby.Position;
								_Grassland._AllBlackEnvironment.MoveTo(_entity63_803,
									_target63_803, 
									_speed63_803, 
									_predicate63_803);
								
								return new Tuple<double, double>(Position.X, Position.Y);
							}).Invoke()
							;}
					;} ;
			double distanceNearestWallaby = new Func<double>(() => {
			var _target66_878 = nearestWallaby;
			return Mars.Mathematics.Distance.Calculate(Mars.Mathematics.SpaceDistanceMetric.Euclidean, this.Position.PositionArray, _target66_878.Position.PositionArray);
			}).Invoke();
			if(distanceNearestWallaby <= 1.0) {
							{
							Tackle(nearestWallaby)
							;}
					;} 
			;}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void Tackle(rugby_sim.Wallaby nearestWallaby) 
		{
			{
			System.Console.WriteLine("Gotcha!!");;
			nearestWallaby.Hit()
			;}
			return;
		}
		internal bool _isAlive;
		internal int _executionFrequency;
		
		public rugby_sim.Grassland _Layer_ => _Grassland;
		public rugby_sim.Grassland _Grassland { get; set; }
		public rugby_sim.Grassland grass => _Grassland;
		public Mars.Components.Environments.SpatialHashEnvironment<Wallaby> _WallabyEnvironment { get; set; }
		
		[Mars.Interfaces.LIFECapabilities.PublishForMappingInMars]
		public AllBlack (
		System.Guid _id,
		rugby_sim.Grassland _layer,
		Mars.Interfaces.Layer.RegisterAgent _register,
		Mars.Interfaces.Layer.UnregisterAgent _unregister,
		Mars.Components.Environments.SpatialHashEnvironment<AllBlack> _AllBlackEnvironment,
		double speed
	,	double xcor = 0, double ycor = 0, int freq = 1)
		{
			_Grassland = _layer;
			ID = _id;
			Position = Mars.Interfaces.Environment.Position.CreatePosition(xcor, ycor);
			_Random = new System.Random(ID.GetHashCode());
			this.speed = speed;
			_Grassland._AllBlackEnvironment.Insert(this);
			_register(_layer, this, freq);
			_isAlive = true;
			_executionFrequency = freq;
			{
			System.Console.WriteLine("Initializing");;
			new System.Func<System.Tuple<double,double>>(() => {
				
				var _taget49_637 = new System.Tuple<int,int>(_Random.Next(200),
				_Random.Next(10)
				);
				
				var _object49_637 = this;
				
				_Grassland._AllBlackEnvironment.PosAt(_object49_637, 
					_taget49_637.Item1, _taget49_637.Item2
				);
				return new Tuple<double, double>(Position.X, Position.Y);
			}).Invoke();
			speed = 0.2
			;}
		}
		
		public void Tick()
		{
			{ if (!_isAlive) return; }
			{
			Run()
			;}
		}
		
		public System.Guid ID { get; }
		public Mars.Interfaces.Environment.Position Position { get; set; }
		public bool Equals(AllBlack other) => Equals(ID, other.ID);
		public override int GetHashCode() => ID.GetHashCode();
	}
}
