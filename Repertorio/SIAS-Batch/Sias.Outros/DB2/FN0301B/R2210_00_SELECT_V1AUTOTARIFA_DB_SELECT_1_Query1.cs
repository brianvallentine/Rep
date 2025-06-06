using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.FN0301B
{
    public class R2210_00_SELECT_V1AUTOTARIFA_DB_SELECT_1_Query1 : QueryBasis<R2210_00_SELECT_V1AUTOTARIFA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTINIVIG ,
            DTTERVIG ,
            TIPOCOB ,
            REGIAO ,
            FRANQFAC ,
            CLABONAT ,
            CATTARIF ,
            CATTARIR ,
            VRFROBR_IX,
            VRFRFACC_IX,
            VRFRFACA_IX,
            VRFRADIC_IX,
            TPCDSBAU ,
            TPCPZSEG ,
            TPCBONDM ,
            TPCBONDP ,
            DTINIVIG - 1 DAY
            INTO :V1TARI-DTINIVIG ,
            :V1TARI-DTTERVIG ,
            :V1TARI-TIPOCOB ,
            :V1TARI-REGIAO ,
            :V1TARI-FRANQFAC ,
            :V1TARI-CLABONAT ,
            :V1TARI-CATAUTO ,
            :V1TARI-CATRCF ,
            :V1TARI-VRFROBR-IX ,
            :V1TARI-VRFRFACC-IX ,
            :V1TARI-VRFRFACA-IX ,
            :V1TARI-VRFRADIC-IX ,
            :V1TARI-TPCDSBAU ,
            :V1TARI-TPCPZSEG ,
            :V1TARI-TPCBONDM ,
            :V1TARI-TPCBONDP ,
            :V1TARI-DTINIVIG-1DIA
            FROM SEGUROS.V1AUTOTARIFA
            WHERE NUM_APOLICE = :V1ENDO-NUMAPOL
            AND NRENDOS = :V1ENDO-NRENDOS
            AND NRITEM = :V1AUTO-NRITEM
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DTINIVIG 
							,
											DTTERVIG 
							,
											TIPOCOB 
							,
											REGIAO 
							,
											FRANQFAC 
							,
											CLABONAT 
							,
											CATTARIF 
							,
											CATTARIR 
							,
											VRFROBR_IX
							,
											VRFRFACC_IX
							,
											VRFRFACA_IX
							,
											VRFRADIC_IX
							,
											TPCDSBAU 
							,
											TPCPZSEG 
							,
											TPCBONDM 
							,
											TPCBONDP 
							,
											DTINIVIG - 1 DAY
											FROM SEGUROS.V1AUTOTARIFA
											WHERE NUM_APOLICE = '{this.V1ENDO_NUMAPOL}'
											AND NRENDOS = '{this.V1ENDO_NRENDOS}'
											AND NRITEM = '{this.V1AUTO_NRITEM}'
											WITH UR";

            return query;
        }
        public string V1TARI_DTINIVIG { get; set; }
        public string V1TARI_DTTERVIG { get; set; }
        public string V1TARI_TIPOCOB { get; set; }
        public string V1TARI_REGIAO { get; set; }
        public string V1TARI_FRANQFAC { get; set; }
        public string V1TARI_CLABONAT { get; set; }
        public string V1TARI_CATAUTO { get; set; }
        public string V1TARI_CATRCF { get; set; }
        public string V1TARI_VRFROBR_IX { get; set; }
        public string V1TARI_VRFRFACC_IX { get; set; }
        public string V1TARI_VRFRFACA_IX { get; set; }
        public string V1TARI_VRFRADIC_IX { get; set; }
        public string V1TARI_TPCDSBAU { get; set; }
        public string V1TARI_TPCPZSEG { get; set; }
        public string V1TARI_TPCBONDM { get; set; }
        public string V1TARI_TPCBONDP { get; set; }
        public string V1TARI_DTINIVIG_1DIA { get; set; }
        public string V1ENDO_NUMAPOL { get; set; }
        public string V1ENDO_NRENDOS { get; set; }
        public string V1AUTO_NRITEM { get; set; }

        public static R2210_00_SELECT_V1AUTOTARIFA_DB_SELECT_1_Query1 Execute(R2210_00_SELECT_V1AUTOTARIFA_DB_SELECT_1_Query1 r2210_00_SELECT_V1AUTOTARIFA_DB_SELECT_1_Query1)
        {
            var ths = r2210_00_SELECT_V1AUTOTARIFA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2210_00_SELECT_V1AUTOTARIFA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2210_00_SELECT_V1AUTOTARIFA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1TARI_DTINIVIG = result[i++].Value?.ToString();
            dta.V1TARI_DTTERVIG = result[i++].Value?.ToString();
            dta.V1TARI_TIPOCOB = result[i++].Value?.ToString();
            dta.V1TARI_REGIAO = result[i++].Value?.ToString();
            dta.V1TARI_FRANQFAC = result[i++].Value?.ToString();
            dta.V1TARI_CLABONAT = result[i++].Value?.ToString();
            dta.V1TARI_CATAUTO = result[i++].Value?.ToString();
            dta.V1TARI_CATRCF = result[i++].Value?.ToString();
            dta.V1TARI_VRFROBR_IX = result[i++].Value?.ToString();
            dta.V1TARI_VRFRFACC_IX = result[i++].Value?.ToString();
            dta.V1TARI_VRFRFACA_IX = result[i++].Value?.ToString();
            dta.V1TARI_VRFRADIC_IX = result[i++].Value?.ToString();
            dta.V1TARI_TPCDSBAU = result[i++].Value?.ToString();
            dta.V1TARI_TPCPZSEG = result[i++].Value?.ToString();
            dta.V1TARI_TPCBONDM = result[i++].Value?.ToString();
            dta.V1TARI_TPCBONDP = result[i++].Value?.ToString();
            dta.V1TARI_DTINIVIG_1DIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}