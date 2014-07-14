module HelloTypeProviders.WarcraftJson
open FSharp.Data

// sample urls so the type providers can look at sample data to generate types/intellisense
let [<Literal>] wowRealmUri = "http://us.battle.net/api/wow/realm/status?json=realmstatus"
let [<Literal>] characterUri = "http://us.battle.net/api/wow/character/Rexxar/Maslow"
let [<Literal>] characterPetsUri = "http://us.battle.net/api/wow/character/Rexxar/Maslow?fields=pets"

type WowRealmStatusProvider = JsonProvider<wowRealmUri>
type WowCharacterProvider = JsonProvider<characterUri>
let characterProvider realm characterName = 
    let uri = sprintf "http://us.battle.net/api/wow/character/%s/%s" realm characterName
    WowCharacterProvider.Load  uri
let realmStatus () = WowRealmStatusProvider.Load(wowRealmUri)
