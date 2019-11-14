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
	public class Wallaby : Mars.Interfaces.Agent.IMarsDslAgent {
		private static readonly Mars.Common.Logging.ILogger _Logger = 
					Mars.Common.Logging.LoggerFactory.GetLogger(typeof(Wallaby));
		private readonly System.Random _Random = new System.Random();
		private string __Rule
			 = "";
		public string Rule { 
			get { return __Rule; }
			set{
				if(__Rule != value) __Rule = value;
			}
		}
		private int __speed
			 = default(int);
		public int speed { 
			get { return __speed; }
			set{
				if(__speed != value) __speed = value;
			}
		}
		private bool __has_ball
			 = default(bool);
		internal bool has_ball { 
			get { return __has_ball; }
			set{
				if(__has_ball != value) __has_ball = value;
			}
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void Move() 
		{
			{
			new System.Func<Tuple<double,double>>(() => {
				
				var _speed25_341 = 1
			;
				
				var _entity25_341 = this;
				
				Func<double[], bool> _predicate25_341 = null;
				
				var _target25_341 = new System.Tuple<double,double>(this.Position.X,this.Position.Y + speed);
				_Grassland._WallabyEnvironment.MoveTo(_entity25_341,
					 _target25_341.Item1, _target25_341.Item2, 
					_speed25_341, 
					_predicate25_341);
				
				return new Tuple<double, double>(Position.X, Position.Y);
			}).Invoke()
			;}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void Pass() 
		{
			{
			has_ball = false
			;}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void Hit() {
			{
			new System.Action(() => {
				var _target33_436 = this;
				if (_target33_436 != null) {
					_Grassland._KillWallaby(_target33_436, _target33_436._executionFrequency);
				}
			}).Invoke()
			;}
			
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public bool GetHasBall() {
			{
			return has_ball
			;}
			
			return default(bool);;
		}
		internal bool _isAlive;
		internal int _executionFrequency;
		
		public rugby_sim.Grassland _Layer_ => _Grassland;
		public rugby_sim.Grassland _Grassland { get; set; }
		public rugby_sim.Grassland grass => _Grassland;
		
		[Mars.Interfaces.LIFECapabilities.PublishForMappingInMars]
		public Wallaby (
		System.Guid _id,
		rugby_sim.Grassland _layer,
		Mars.Interfaces.Layer.RegisterAgent _register,
		Mars.Interfaces.Layer.UnregisterAgent _unregister,
		Mars.Components.Environments.SpatialHashEnvironment<Wallaby> _WallabyEnvironment,
		int speed
	,	double xcor = 0, double ycor = 0, int freq = 1)
		{
			_Grassland = _layer;
			ID = _id;
			Position = Mars.Interfaces.Environment.Position.CreatePosition(xcor, ycor);
			_Random = new System.Random(ID.GetHashCode());
			this.speed = speed;
			_Grassland._WallabyEnvironment.Insert(this);
			_register(_layer, this, freq);
			_isAlive = true;
			_executionFrequency = freq;
			{
			new System.Func<System.Tuple<double,double>>(() => {
				
				var _taget15_245 = new System.Tuple<int,int>(_Random.Next(250),
				5);
				
				var _object15_245 = this;
				
				_Grassland._WallabyEnvironment.PosAt(_object15_245, 
					_taget15_245.Item1, _taget15_245.Item2
				);
				return new Tuple<double, double>(Position.X, Position.Y);
			}).Invoke();
			has_ball = true;
			speed = 1
			;}
		}
		
		public void Tick()
		{
			{ if (!_isAlive) return; }
			{
			Move()
			;}
		}
		
		public System.Guid ID { get; }
		public Mars.Interfaces.Environment.Position Position { get; set; }
		public bool Equals(Wallaby other) => Equals(ID, other.ID);
		public override int GetHashCode() => ID.GetHashCode();
	}
}
