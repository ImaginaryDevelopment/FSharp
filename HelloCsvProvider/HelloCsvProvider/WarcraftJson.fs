module HelloTypeProviders.WarcraftJson
open FSharp.Data
// http://jsfiddle.net/Maslow/j2qfN/
// sample urls so the type providers can look at sample data to generate types/intellisense
let [<Literal>] wowRealmUri = "http://us.battle.net/api/wow/realm/status?json=realmstatus"
let [<Literal>] characterUri = "http://us.battle.net/api/wow/character/Rexxar/Maslow"
let [<Literal>] characterPetsUri = "http://us.battle.net/api/wow/character/Rexxar/Maslow?fields=pets"

type WowRealmStatusProvider = JsonProvider<wowRealmUri>
type WowCharacterProvider = JsonProvider<characterUri>
type WowPetProvider = JsonProvider<characterPetsUri>

let realmStatus () = WowRealmStatusProvider.Load(wowRealmUri)

let characterProvider realm characterName = 
    let uri = sprintf "http://us.battle.net/api/wow/character/%s/%s" realm characterName
    WowCharacterProvider.Load  uri

let petProvider realm characterName =
    let uri = sprintf "http://us.battle.net/api/wow/character/%s/%s?fields=pets" realm characterName
    WowPetProvider.Load  uri
