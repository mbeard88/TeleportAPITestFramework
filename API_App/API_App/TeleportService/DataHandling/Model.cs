// Teleport CLasses
namespace API_App.TeleportService
{
    public class SingleCityResponse
    {
        public _Embedded _embedded { get; set; }
        public _Links _links { get; set; }
        public int count { get; set; }


        public Bounding_Box bounding_box { get; set; }
        public string continent { get; set; }
        public string full_name { get; set; }
        public bool is_government_partner { get; set; }
        public string mayor { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public string teleport_city_url { get; set; }
        public string ua_id { get; set; }
    }



    public class _Embedded
    {
        public CitySearchResults[] citysearchresults { get; set; }
    }

    public class CitySearchResults
    {
        public _Links _links { get; set; }
        public object[] matching_alternate_names { get; set; }
        public string matching_full_name { get; set; }
    }

    public class _Links
    {
        public CityItem cityitem { get; set; }

        public Cury[] curies { get; set; }
        public Self self { get; set; }
        public UaAdmin1Divisions[] uaadmin1divisions { get; set; }
        public UaCities uacities { get; set; }
        public UaContinent uacontinent { get; set; }
        public UaCountries[] uacountries { get; set; }
        public UaDetails uadetails { get; set; }
        public UaIdentifyingCity uaidentifyingcity { get; set; }
        public UaImages uaimages { get; set; }
        public UaPrimaryCities[] uaprimarycities { get; set; }
        public UaSalaries uasalaries { get; set; }
        public UaScores uascores { get; set; }
    }

    public class CityItem
    {
        public string href { get; set; }
    }

    public class _Links1
    {
        public Cury[] curies { get; set; }
        public Self self { get; set; }
    }

    public class Self
    {
        public string href { get; set; }
    }


    public class Cury
    {
        public string href { get; set; }
        public string name { get; set; }
        public bool templated { get; set; }
    }


    // Postcodes Classes


    public class BulkPostcodesResponse
    {
        public int status { get; set; }
        public Result[] result { get; set; }
    }
    public class SinglePostcodeResponse
    {
        public int status { get; set; }
        public PostCode result { get; set; }
    }

    public class Result
    {
        public string query { get; set; }
        public PostCode result { get; set; }
    }

    public class PostCode
    {
        public string postcode { get; set; }
        public int quality { get; set; }
        public int eastings { get; set; }
        public int northings { get; set; }
        public string country { get; set; }
        public string nhs_ha { get; set; }
        public float longitude { get; set; }
        public float latitude { get; set; }
        public string european_electoral_region { get; set; }
        public string primary_care_trust { get; set; }
        public string region { get; set; }
        public string lsoa { get; set; }
        public string msoa { get; set; }
        public string incode { get; set; }
        public string outcode { get; set; }
        public string parliamentary_constituency { get; set; }
        public string admin_district { get; set; }
        public string parish { get; set; }
        public string admin_county { get; set; }
        public string admin_ward { get; set; }
        public string ced { get; set; }
        public string ccg { get; set; }
        public string nuts { get; set; }
        public Codes codes { get; set; }
    }

    public class Codes
    {
        public string admin_district { get; set; }
        public string admin_county { get; set; }
        public string admin_ward { get; set; }
        public string parish { get; set; }
        public string parliamentary_constituency { get; set; }
        public string ccg { get; set; }
        public string ccg_id { get; set; }
        public string ced { get; set; }
        public string nuts { get; set; }
        public string lsoa { get; set; }
        public string msoa { get; set; }
        public string lau2 { get; set; }
    }


    //HERE






    public class UaCities
    {
        public string href { get; set; }
    }

    public class UaContinent
    {
        public string href { get; set; }
        public string name { get; set; }
    }

    public class UaDetails
    {
        public string href { get; set; }
    }

    public class UaIdentifyingCity
    {
        public string href { get; set; }
        public string name { get; set; }
    }

    public class UaImages
    {
        public string href { get; set; }
    }

    public class UaSalaries
    {
        public string href { get; set; }
    }

    public class UaScores
    {
        public string href { get; set; }
    }



    public class UaAdmin1Divisions
    {
        public string href { get; set; }
        public string name { get; set; }
    }

    public class UaCountries
    {
        public string href { get; set; }
        public string name { get; set; }
    }

    public class UaPrimaryCities
    {
        public string href { get; set; }
        public string name { get; set; }
    }

    public class Bounding_Box
    {
        public Latlon latlon { get; set; }
    }

    public class Latlon
    {
        public float east { get; set; }
        public float north { get; set; }
        public float south { get; set; }
        public float west { get; set; }
    }
}


