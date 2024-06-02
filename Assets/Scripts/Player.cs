using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Windows;
using Input = UnityEngine.Input;

public class Player : MonoBehaviour
{   
    //public or private reference
    //data type (int , float , bool , string)
    //every variabe has a name 
    //optional value assigned
    [SerializeField]
    private float _speed = 3.5f;
    private float _speedMultiplier = 2;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _tripleshotPrefab;
    [SerializeField]
    private float _fireRate = 0.5f;
    private float _canFire = -1f;
    [SerializeField]
    private int _lives = 3;
    private SpawnManager _spawnManager;

    private bool _isTripleShotActive = false ;
    private bool _isSpeedBoostActive = false ;
    private bool _isShieldsActive = false ;
    public bool _isPlayerOne = false ;
    public bool _isPlayerTwo = false ;

    [SerializeField]
    private GameObject _shieldVisualizer;

    [SerializeField]
    private GameObject _leftEngine, _rightEngine;

    [SerializeField]
    private int _score;

    private UIManager _uiManager;

    [SerializeField]
    private AudioClip _laserSoundClip;
    private AudioSource _audioSource;
    private _gameManager _gameManager;

    private int hitCount = 0;

    // Start is called before the first frame update
    void Start( )
    {
        //take the current position = new position (0,0,0)

        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if (_uiManager != null)
        {
           _uiManager.UpdateLives(_lives);
        }

        _gameManager = GameObject.Find("GameManager").GetComponent<_gameManager>();

        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>(); //find the object. Get the component.

        if (_spawnManager != null)
        {
            //_spawnManager.StartSpawning();
        }
        _audioSource = GetComponent<AudioSource>();
        hitCount = 0;

        if (_gameManager.isCoopMode == false)
        {
            transform.position = new UnityEngine.Vector3(0, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_isPlayerOne == true)
        {
            PlayerOneMovement();
            if (Input.GetKeyDown(KeyCode.Space)|| Input.GetMouseButton(0) && _isPlayerOne == true)
            {
                FireLaser();
            }
        }
        if (_isPlayerTwo == true)
        {
            PlayerTwoMovement();
            if (Input.GetKeyDown(KeyCode.RightControl))
            {
                FireLaser();
            }
        }
    }
    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        UnityEngine.Vector3 direction = new UnityEngine.Vector3(horizontalInput, verticalInput, 0);

        transform.Translate(direction * _speed * Time.deltaTime);

        transform.position = new UnityEngine.Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.8f, 0), 0);

        if (transform.position.x > 11.3f)
        {
            transform.position = new UnityEngine.Vector3(-11.3f, transform.position.y, 0);
        }
        else if (transform.position.x < -11.3f)
        {
            transform.position = new UnityEngine.Vector3(11.3f, transform.position.y, 0);
        }
    }

    private void PlayerOneMovement()
    {
        if (_isTripleShotActive == true)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(UnityEngine.Vector3.up * _speed * 1.5f * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(UnityEngine.Vector3.right * _speed * 1.5f * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(UnityEngine.Vector3.down * _speed * 1.5f * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(UnityEngine.Vector3.left * _speed * 1.5f * Time.deltaTime);
            }
        }

        else
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(UnityEngine.Vector3.up * _speed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(UnityEngine.Vector3.right * _speed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(UnityEngine.Vector3.down * _speed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(UnityEngine.Vector3.left * _speed * Time.deltaTime);
            }
        }

        transform.position = new UnityEngine.Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.8f, 0), 0);
        if (transform.position.x > 11.3f)
        {
            transform.position = new UnityEngine.Vector3(-11.3f, transform.position.y, 0);
        }
        else if (transform.position.x < -11.3f)
        {
            transform.position = new UnityEngine.Vector3(11.3f, transform.position.y, 0);
        }
    }
    private void PlayerTwoMovement()
    {
        if (_isTripleShotActive == true)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(UnityEngine.Vector3.up * _speed * 1.5f * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(UnityEngine.Vector3.right * _speed * 1.5f * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(UnityEngine.Vector3.down * _speed * 1.5f * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(UnityEngine.Vector3.left * _speed * 1.5f * Time.deltaTime);
            }
    }

        else
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(UnityEngine.Vector3.up * _speed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(UnityEngine.Vector3.right * _speed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(UnityEngine.Vector3.down * _speed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(UnityEngine.Vector3.left * _speed * Time.deltaTime);
            }
        }

        transform.position = new UnityEngine.Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.8f, 0), 0);
        if (transform.position.x > 11.3f)
        {
            transform.position = new UnityEngine.Vector3(-11.3f, transform.position.y, 0);
        }
        else if (transform.position.x < -11.3f)
        {
            transform.position = new UnityEngine.Vector3(11.3f, transform.position.y, 0);
        }
    }
    void FireLaser()
    {
        if (Time.time > _canFire)
        {
            _audioSource.Play();

            if (_isTripleShotActive == true)
            {
                Instantiate(_tripleshotPrefab, transform.position, UnityEngine.Quaternion.identity);
            }

            else
            {
                Instantiate(_laserPrefab, transform.position + new UnityEngine.Vector3(0, 0.88f, 0), UnityEngine.Quaternion.identity);
            }

            _canFire = Time.time + _fireRate;
        }
    }

    //void FireLaserTwo()
    //{
    //    if (Time.time > _canFire)
    //    {
    //        _audioSource.Play();

    //        if (_isTripleShotActive == true)
    //        {
    //            Instantiate(_tripleshotPrefab, transform.position, UnityEngine.Quaternion.identity);
    //        }

    //        else
    //        {
    //            Instantiate(_laserPrefab, transform.position + new UnityEngine.Vector3(0, 0.88f, 0), UnityEngine.Quaternion.identity);
    //        }

    //        _canFire = Time.time + _fireRate;
    //    }
    //}

    public void Damage()
    {
        if (_isShieldsActive == true)
        {
            _isShieldsActive = false;
            _shieldVisualizer.SetActive(false);
            return;
        }

        _lives--;

        if (_lives == 2)
        {
            _leftEngine.SetActive(true);
        }
        else if (_lives == 1)
        {
            _rightEngine.SetActive(true);
        }

        _uiManager.UpdateLives(_lives);

        if (_lives < 1)
        {
            _spawnManager.OnPlayerDeath();
            Destroy(this.gameObject);
        }
    }

    public void TripleShotActive()
    { 
        _isTripleShotActive = true;
        StartCoroutine(TripleShotPowerDownRoutine()); 
    }

    IEnumerator TripleShotPowerDownRoutine() 
    {
        yield return new WaitForSeconds(5.0f);
        _isTripleShotActive = false;
    }

    public void SpeedBoostActive()
    {
        _isSpeedBoostActive = true;
        _speed *= _speedMultiplier;
        StartCoroutine(SpeedBoostPowerDownRoutine());
    }

    IEnumerator SpeedBoostPowerDownRoutine() 
    {
        yield return new WaitForSeconds(5.0f);
        _isSpeedBoostActive = false;
        _speed /= _speedMultiplier;
    }

    public void ShieldsActive()
    {
        _isShieldsActive = true;
        _shieldVisualizer.SetActive(true);
    }

    public void AddScore(int points)
    { 
        _score += points;
        _uiManager.UpdateScore(_score);
    }
}
