using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Support.V4.Widget;
using Android.Support.V4.View;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Support.V7.Widget;
using libuy.Helper;
using System.Collections.Generic;
using Xamarin.Essentials;
using ZXing.Mobile;
using Android.Widget;
using Android.Content.PM;
using Android.Graphics.Drawables;

namespace libuy
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true, ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.KeyboardHidden)]
    public class MainActivity : AppCompatActivity, NavigationView.IOnNavigationItemSelectedListener
    {
        private RecyclerView mRecyclerView; //OBTENEMOS UNA REFERENCIA DEL RECYCLERVIEW
        private RecyclerView.Adapter mAdapter;
        private RecyclerView.LayoutManager layoutManager;
        private List<Data> lstData = new List<Data>();

        private DrawerLayout drawer;
        private ActionBarDrawerToggle toggle;
        private NavigationView navigationView;
        private Button btnAdd;

        private FloatingActionButton fabScanDefaultView;
        MobileBarcodeScanner scanner;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);


            //Mostrar el toolbar
            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar_main);
            SetSupportActionBar(toolbar);

            //Iniciar el boton agregar items
            btnAdd = this.FindViewById<Button>(Resource.Id.btnAdd);
            btnAdd.Click += BtnAdd_Click;

            //Mostrar el panel deslizante
            drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            toggle = new ActionBarDrawerToggle(this, drawer, toolbar, Resource.String.navigation_drawer_open,
                Resource.String.navigation_drawer_close);
            drawer.AddDrawerListener(toggle);
            toggle.SyncState();//Mostrar el menu hamburguesa

            //Mostrar items en el panel de navegacion
            navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.SetNavigationItemSelectedListener(this);

            //Crear una nueva instancia de nuestro Scanner
            MobileBarcodeScanner.Initialize(Application);
            fabScanDefaultView = FindViewById<FloatingActionButton>(Resource.Id.fabAdd);
            fabScanDefaultView.Click += async delegate
            {
                scanner = new MobileBarcodeScanner();

                //Decir a nuestro Scanner que use la superposicion predeterminada
                scanner.UseCustomOverlay = false;

                //Podemos especificar el texto superior e inferior de nuestra disposicion predeterminada
                scanner.TopText = "Presiones para enfocar la imagen en el codio de barras";
                scanner.BottomText = "Espere a que se realice la operación automáticamente";

                //Empezar a escanear
                var result = await scanner.Scan();
                HandleScanResult(result);

            };

            //Iniciar la decoracion
            IinitRecylcerView();

        }

        private void IinitRecylcerView()
        {
            mRecyclerView = FindViewById<RecyclerView>(Resource.Id.recycler_view_main);//OBTENEMOS NUESTRO RECYCLERVIEW DECLARADO EN UN XAML
            mRecyclerView.AddItemDecoration(new myDecoration(this));
            mRecyclerView.HasFixedSize = true;//ESTA LINEA MEJORA EL RENDIMIENTO, SI SABEMOS QUE EL CONTENIDO NO VA A AFECTAR EL TAMAÑO DEL RECYCLERVIEW 
        }


        private void BtnAdd_Click(object sender, System.EventArgs e)
        {
            InitData();
            layoutManager = new LinearLayoutManager(this);//NUESTRO RECYCLERVIEW USARA UN LINEAR LAYOUT MANAGER
            mRecyclerView.SetLayoutManager(layoutManager);//NUESTRO RECYCLERVIEW SE VA A PINTAR EN FUNCIÓN AL LAYOUTMANAGER QUE RECIBA COMO PARAMETRO
                                                          // recycler.AddItemDecoration(new myDecoration(recycler.Context));

            mAdapter = new MyAdapter(lstData);//ASOCIAMOS UN ADAPTER
            mRecyclerView.SetAdapter(mAdapter);

        }
        int cont = 0;
        private void InitData()
        {

            lstData.Add(new Data() { data_numeration = cont, data_title = "NUEVO PRODUCTO", data_description = cont.ToString() + "Descripcion del producto" });
            cont++;
        }


        void HandleScanResult(ZXing.Result result)
        {
            var msg = "";
            if (result != null && !string.IsNullOrEmpty(result.Text))
                msg = "Realizado!" + result.Text;
            else
                msg = "Ups!, Error de operación";

            RunOnUiThread(() => Toast.MakeText(this, msg, ToastLength.Short).Show());
        }


        //Ir hacia atras
        public override void OnBackPressed()
        {
            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            if (drawer.IsDrawerOpen(GravityCompat.Start))
            {
                drawer.CloseDrawer(GravityCompat.Start);
            }
            else
            {
                base.OnBackPressed();
            }
        }

        //Llenar el menu principal
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        //Seleccionar alguna opcion del menu principal
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }
            return base.OnOptionsItemSelected(item);
        }

        //Seleccionar alguna opcion del panel de navegacion
        public bool OnNavigationItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.nav_camera)
            {
                //Handle the camera action
            }
            else if (id == Resource.Id.nav_gallery)
            {

            }

            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            drawer.CloseDrawer(GravityCompat.Start);
            return true;
        }


        //Pedir permisos al SO de ser necesario
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);

        }
    }
}
