using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0847B
{
    public class R2320_00_SELECT_V1AUTOAPOL_DB_SELECT_1_Query1 : QueryBasis<R2320_00_SELECT_V1AUTOAPOL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            CDVEICL,
            ANOVEICL,
            ANOMOD,
            PLACAUF,
            PLACALET,
            PLACANR,
            CHASSIS,
            NRPRRESS
            INTO :V1DVEI-CDVEICL,
            :V1AUAP-ANOVEICL,
            :V1AUAP-ANOMOD,
            :V1AUAP-PLACAUF,
            :V1AUAP-PLACALET,
            :V1AUAP-PLACANR,
            :V1AUAP-CHASSIS ,
            :V1AUAP-NRPRRESS
            FROM SEGUROS.V1AUTOAPOL
            WHERE NRITEM = :V1SAUT-NRITEM
            AND NUM_APOLICE = :V1MSIN-NUM-APOL
            AND NRENDOS = :V1MSIN-NRENDOS
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											CDVEICL
							,
											ANOVEICL
							,
											ANOMOD
							,
											PLACAUF
							,
											PLACALET
							,
											PLACANR
							,
											CHASSIS
							,
											NRPRRESS
											FROM SEGUROS.V1AUTOAPOL
											WHERE NRITEM = '{this.V1SAUT_NRITEM}'
											AND NUM_APOLICE = '{this.V1MSIN_NUM_APOL}'
											AND NRENDOS = '{this.V1MSIN_NRENDOS}'";

            return query;
        }
        public string V1DVEI_CDVEICL { get; set; }
        public string V1AUAP_ANOVEICL { get; set; }
        public string V1AUAP_ANOMOD { get; set; }
        public string V1AUAP_PLACAUF { get; set; }
        public string V1AUAP_PLACALET { get; set; }
        public string V1AUAP_PLACANR { get; set; }
        public string V1AUAP_CHASSIS { get; set; }
        public string V1AUAP_NRPRRESS { get; set; }
        public string V1MSIN_NUM_APOL { get; set; }
        public string V1MSIN_NRENDOS { get; set; }
        public string V1SAUT_NRITEM { get; set; }

        public static R2320_00_SELECT_V1AUTOAPOL_DB_SELECT_1_Query1 Execute(R2320_00_SELECT_V1AUTOAPOL_DB_SELECT_1_Query1 r2320_00_SELECT_V1AUTOAPOL_DB_SELECT_1_Query1)
        {
            var ths = r2320_00_SELECT_V1AUTOAPOL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2320_00_SELECT_V1AUTOAPOL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2320_00_SELECT_V1AUTOAPOL_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1DVEI_CDVEICL = result[i++].Value?.ToString();
            dta.V1AUAP_ANOVEICL = result[i++].Value?.ToString();
            dta.V1AUAP_ANOMOD = result[i++].Value?.ToString();
            dta.V1AUAP_PLACAUF = result[i++].Value?.ToString();
            dta.V1AUAP_PLACALET = result[i++].Value?.ToString();
            dta.V1AUAP_PLACANR = result[i++].Value?.ToString();
            dta.V1AUAP_CHASSIS = result[i++].Value?.ToString();
            dta.V1AUAP_NRPRRESS = result[i++].Value?.ToString();
            return dta;
        }

    }
}