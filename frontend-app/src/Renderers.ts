import SimpleRenderer from "@arcgis/core/renderers/SimpleRenderer.js";
import UniqueValueRenderer from "@arcgis/core/renderers/UniqueValueRenderer.js";
import { DeliverySymbol } from "./DeliverySymbol";
import { DepotSymbol } from "./DepotSymbol";
import { PickupSymbol } from "./PickupSymbol";
import { TrainPickupSymbol } from "./TrainDeliverySymbol";
export const deliveryRenderer = new SimpleRenderer({symbol: DeliverySymbol, label: "Mottagningspunkt"});
export const depotRenderer = new SimpleRenderer({symbol: DepotSymbol, label: "Depot"});
export const pickupRenderer = new UniqueValueRenderer({field: "pickupType", uniqueValueInfos: [{
    value: 0,
    label: "Butiker",
    symbol: PickupSymbol
},
{
    value: 1,
    label: "SJ",
    symbol: TrainPickupSymbol
}
]})


export const pickupRenderer1 = new SimpleRenderer({symbol: PickupSymbol, label: "Butik"})
export const trainDeliveryRenderer = new SimpleRenderer({symbol: TrainPickupSymbol, label: "Annan upphämtningspunkt"})