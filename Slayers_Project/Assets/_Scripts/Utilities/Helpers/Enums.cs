using System.ComponentModel;


/// <summary>
/// les trois Axes 3d.
/// </summary>
public enum Axis3D
{
	x,
	y,
	z}
;

/// <summary>
/// Les 2 axes 2D
/// </summary>
public enum Axis2D
{
	x,
	y}
;

/// <summary>
/// Retour.
/// </summary>
public enum Retour
{
	[Description ("")]
	None = 0,
	[Description ("\r")]
	CR = 1,
	[Description ("\n")]
	LF = 2,
	[Description ("\r\n")]
	CRLF = 3}
;


/// <summary>
/// Les differentes Fin de ligne.
/// </summary>
public static class FinDeLigne
{
	public const string CR = "\r";
	public const string LF = "\n";
	public const string CRLF = "\r\n";

};



/// <summary>
/// Clusing type.
/// </summary>
public enum	ClusingType
{
	[Description ("Inclusive mini and maxi")]
	II,
	[Description ("Inclusive mini and Exclusive maxi")]
	IE,
	[Description ("Exclusive mini and Inclusive maxi")]
	EI,
	[Description ("Exclusive mini and maxi")]
	EE
}

/// <summary>
/// bps serial Data rates enum.
/// </summary>
public enum DataRates : int
{
	_300 = 300,
	_600 = 600,
	_1200 = 1200,
	_2400 = 2400,
	_9600 = 9600,
	_14400 = 14400,
	_19200 = 19200,
	_38400 = 38400,
	_57600 = 57600,
	_115200 = 115200}
;

/// <summary>
/// Input type in InputManager.
/// </summary>
public enum InputType
{
	KeyOrMouseButton,
	MouseMovement,
	JoystickAxis,
};


public enum LayersEnum : int
{
	Default = 0,
	TransparentFX = 1,
	IgnoreRaycast = 2,
	Water = 4,
	UI = 5
}
