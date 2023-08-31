import Map from '@arcgis/core/Map.js';
import FormTemplate from '@arcgis/core/form/FormTemplate.js';
import FieldElement from '@arcgis/core/form/elements/FieldElement.js';
import ComboBoxInput from '@arcgis/core/form/elements/inputs/ComboBoxInput.js';
import FeatureLayer from '@arcgis/core/layers/FeatureLayer.js';
import CodedValueDomain from '@arcgis/core/layers/support/CodedValueDomain.js';
import MapView from '@arcgis/core/views/MapView.js';
import Editor from '@arcgis/core/widgets/Editor.js';
import { useEffect } from 'react';
import './App.css';
import { deliveryRenderer, depotRenderer, pickupRenderer } from './Renderers';
import { AllwinHeader } from './allwin-header';
import { useGetAllVehicles } from './utils/vehicles';
import { useGetAllDepots } from './utils/depots';
import { useGetAllDeliveries } from './utils/deliveries';
import { useGetAllPickups } from './utils/pickups';

function App() {
  const vehicleQuery = useGetAllVehicles();
  const depotQuery = useGetAllDepots();
  const deliveryQuery = useGetAllDeliveries();
  const pickupQuery = useGetAllPickups();

  const ready = Boolean(vehicleQuery.data && depotQuery.data && deliveryQuery.data && pickupQuery.data);

  useEffect(() => {
    if (ready) {
      const map = new Map({
        basemap: 'dark-gray-vector'
      });

      const View = new MapView({
        map,
        container: 'view',
        center: [2010905.3401258923, 8251874.044066464]
      });

      const depotLayer = new FeatureLayer({
        source: [],
        title: 'Depåer',
        renderer: depotRenderer,
        fields: [
          {
            name: 'objectid',
            alias: 'ObjectID',
            type: 'oid'
          },
          {
            name: 'gid',
            alias: 'gid',
            type: 'string'
          },
          {
            name: 'depotName',
            alias: 'Depot',
            type: 'string'
          }
        ],
        objectIdField: 'objectid',
        geometryType: 'point'
      });
      const pickUpLayer = new FeatureLayer({
        source: [],
        title: 'Butiker',
        renderer: pickupRenderer,
        fields: [
          {
            name: 'objectid',
            alias: 'ObjectID',
            type: 'oid'
          },
          {
            name: 'gid',
            alias: 'gid',
            type: 'string'
          },
          {
            name: 'pickupName',
            alias: 'Butik',
            type: 'string'
          },
          {
            name: 'pickupType',
            alias: 'Typ av upphämtningspunkt',
            type: 'integer',
            defaultValue: 0,
            domain: new CodedValueDomain({
              name: 'pickupTypeDomain',
              codedValues: [
                {
                  name: 'Butik',
                  code: 0
                },
                {
                  name: 'SJ',
                  code: 1
                }
              ]
            })
          },
          {
            name: 'contactName',
            alias: 'Kontaktnamn',
            type: 'string'
          },
          {
            name: 'contactPhoneNo',
            alias: 'Kontakts telefonnummer',
            type: 'string'
          },
          {
            name: 'averageVolume',
            alias: 'Förväntad volym',
            type: 'integer'
          },
          {
            name: 'openTime',
            alias: 'Öppningstid',
            type: 'string'
          },
          {
            name: 'closeTime',
            alias: 'Stängningstid',
            type: 'string'
          },
          {
            name: 'averageStoptime',
            alias: 'Ungefärlig lastningstid (minuter)',
            type: 'integer'
          },
          {
            name: 'vehicleId',
            alias: 'Vilken bil',
            type: 'string',
            domain: new CodedValueDomain({
              name: 'carDomain',
              codedValues: [
                {
                  name: 'Bil 1',
                  code: 'hej'
                },
                {
                  name: 'Bil 2',
                  code: 'då'
                }
              ]
            })
          },
          {
            name: 'active',
            alias: 'Aktiv',
            type: 'small-integer',
            defaultValue: 1,
            domain: new CodedValueDomain({
              name: 'activePickupDomain',
              codedValues: [
                {
                  name: 'Aktiv',
                  code: 1
                },
                {
                  name: 'Inaktiv',
                  code: 0
                }
              ]
            })
          }
        ],
        objectIdField: 'objectid',
        geometryType: 'point'
      });
      const deliveryLayer = new FeatureLayer({
        source: [],
        title: 'Mottagningspunkt',
        renderer: deliveryRenderer,
        fields: [
          {
            name: 'objectid',
            alias: 'ObjectID',
            type: 'oid'
          },
          {
            name: 'gid',
            alias: 'gid',
            type: 'string'
          },
          {
            name: 'deliveryName',
            alias: 'Mottagningsnamn',
            type: 'string'
          },
          {
            name: 'contactName',
            alias: 'Kontaktperson',
            type: 'string'
          },
          {
            name: 'contactPhone',
            alias: 'Kontakts telefonnummer',
            type: 'string'
          },
          {
            name: 'stopTime',
            alias: 'Ungefärlig lastningstid (minuter)',
            type: 'integer'
          },
          {
            name: 'vehicleId',
            alias: 'Vilken bil',
            type: 'string',
            domain: new CodedValueDomain({
              name: 'carDomain',
              codedValues:
                vehicleQuery.data?.map(vehicle => ({
                  name: vehicle.vehicleName,
                  code: vehicle.gid
                })) || []
            })
          },
          {
            name: 'deliveryDay',
            alias: 'Leveransdagar',
            type: 'string'
          }
        ],
        objectIdField: 'objectid',
        geometryType: 'point'
      });

      map.add(depotLayer);
      map.add(pickUpLayer);
      map.add(deliveryLayer);

      const editor = new Editor({
        view: View,
        layerInfos: [
          {
            layer: depotLayer,
            formTemplate: new FormTemplate({
              elements: [
                new FieldElement({
                  fieldName: 'depotName',
                  label: 'Depot'
                })
              ]
            })
          },
          {
            layer: deliveryLayer,
            formTemplate: new FormTemplate({
              elements: [
                new FieldElement({
                  fieldName: 'deliveryName',
                  label: 'Mottagningsnamn'
                }),
                new FieldElement({
                  fieldName: 'contactName',
                  label: 'Kontakt'
                }),
                new FieldElement({
                  fieldName: 'contactPhone',
                  label: 'Kontakts telefonnummer'
                }),
                new FieldElement({
                  fieldName: 'deliveryDay',
                  label: 'Leveransdagar'
                }),
                new FieldElement({
                  fieldName: 'stopTime',
                  label: 'Ungefärlig lastningstid (minuter)'
                }),
                new FieldElement({
                  fieldName: 'vehicleId',
                  label: 'Bilnummer'
                })
              ]
            })
          },
          {
            layer: pickUpLayer,
            formTemplate: new FormTemplate({
              elements: [
                new FieldElement({
                  fieldName: 'pickupName',
                  label: 'Upphämtningspunkt'
                }),
                new FieldElement({
                  fieldName: 'contactName',
                  label: 'Kontaktnamn'
                }),
                new FieldElement({
                  fieldName: 'contactPhoneNo',
                  label: 'Kontakts telefonnummer'
                }),
                new FieldElement({
                  fieldName: 'averageStoptime',
                  label: 'Ungefärlig lastningstid (minuter)'
                }),
                new FieldElement({
                  fieldName: 'pickupType',
                  label: 'Typ av upphämtningspunkt',
                  input: new ComboBoxInput({
                    showNoValueOption: false
                  })
                }),
                new FieldElement({
                  fieldName: 'vehicleId',
                  label: 'Bilnummer'
                }),
                new FieldElement({
                  fieldName: 'active',
                  label: 'Aktiv'
                })
              ]
            })
          }
        ]
      });
      editor.viewModel.sketchViewModel.on('create', event => {
        console.log(event);
      });
      View.ui.add(editor, 'top-right');

      return () => {
        map.removeAll(), View.ui.remove(editor), View.destroy();
      };
    }
  }, [ready, vehicleQuery.data, pickupQuery.data, deliveryQuery.data, depotQuery.data]);

  return (
    <>
      <AllwinHeader />
      <div id="view" style={{ height: '100vh', width: '100vw' }}></div>
    </>
  );
}

export default App;
