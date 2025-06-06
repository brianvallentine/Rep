using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0812B
{
    public class R1800_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1 : QueryBasis<R1800_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT OCORHIST ,
            PRM_TARIFARIO_IX ,
            VAL_DESCONTO_IX ,
            OTNPRLIQ ,
            OTNADFRA ,
            VLCOMISIX ,
            OTNTOTAL
            INTO
            :V1CPRE-OCORHIST ,
            :V1CPRE-PRMTAR-IX ,
            :V1CPRE-VLDESC-IX ,
            :V1CPRE-OTNPRLIQ ,
            :V1CPRE-OTNADFRA ,
            :V1CPRE-VLCOMS-IX ,
            :V1CPRE-OTNTOTAL
            FROM
            SEGUROS.V1COSSEG_PREM
            WHERE
            CONGENER = :V1CHIS-CONGENER
            AND NUM_APOLICE = :V1CHIS-NUM-APOL
            AND NRENDOS = :V1CHIS-NUM-ENDS
            AND NRPARCEL = :V1CHIS-NRPARCEL
            AND TIPSGU = '1'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT OCORHIST 
							,
											PRM_TARIFARIO_IX 
							,
											VAL_DESCONTO_IX 
							,
											OTNPRLIQ 
							,
											OTNADFRA 
							,
											VLCOMISIX 
							,
											OTNTOTAL
											FROM
											SEGUROS.V1COSSEG_PREM
											WHERE
											CONGENER = '{this.V1CHIS_CONGENER}'
											AND NUM_APOLICE = '{this.V1CHIS_NUM_APOL}'
											AND NRENDOS = '{this.V1CHIS_NUM_ENDS}'
											AND NRPARCEL = '{this.V1CHIS_NRPARCEL}'
											AND TIPSGU = '1'";

            return query;
        }
        public string V1CPRE_OCORHIST { get; set; }
        public string V1CPRE_PRMTAR_IX { get; set; }
        public string V1CPRE_VLDESC_IX { get; set; }
        public string V1CPRE_OTNPRLIQ { get; set; }
        public string V1CPRE_OTNADFRA { get; set; }
        public string V1CPRE_VLCOMS_IX { get; set; }
        public string V1CPRE_OTNTOTAL { get; set; }
        public string V1CHIS_CONGENER { get; set; }
        public string V1CHIS_NUM_APOL { get; set; }
        public string V1CHIS_NUM_ENDS { get; set; }
        public string V1CHIS_NRPARCEL { get; set; }

        public static R1800_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1 Execute(R1800_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1 r1800_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1)
        {
            var ths = r1800_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1800_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1800_00_SELECT_V1COSSEG_PREM_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1CPRE_OCORHIST = result[i++].Value?.ToString();
            dta.V1CPRE_PRMTAR_IX = result[i++].Value?.ToString();
            dta.V1CPRE_VLDESC_IX = result[i++].Value?.ToString();
            dta.V1CPRE_OTNPRLIQ = result[i++].Value?.ToString();
            dta.V1CPRE_OTNADFRA = result[i++].Value?.ToString();
            dta.V1CPRE_VLCOMS_IX = result[i++].Value?.ToString();
            dta.V1CPRE_OTNTOTAL = result[i++].Value?.ToString();
            return dta;
        }

    }
}