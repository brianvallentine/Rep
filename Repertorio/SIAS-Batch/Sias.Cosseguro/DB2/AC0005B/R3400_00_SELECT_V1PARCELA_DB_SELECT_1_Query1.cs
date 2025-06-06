using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0005B
{
    public class R3400_00_SELECT_V1PARCELA_DB_SELECT_1_Query1 : QueryBasis<R3400_00_SELECT_V1PARCELA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE ,
            NRENDOS ,
            NRPARCEL ,
            PRM_TARIFARIO_IX ,
            VAL_DESCONTO_IX ,
            OTNPRLIQ ,
            OTNADFRA ,
            OTNCUSTO ,
            OTNIOF ,
            OTNTOTAL
            INTO :V1PARC-NUM-APOL ,
            :V1PARC-NRENDOS ,
            :V1PARC-NRPARCEL ,
            :V1PARC-PRM-TAR ,
            :V1PARC-VAL-DESC ,
            :V1PARC-OTNPRLIQ ,
            :V1PARC-OTNADFRA ,
            :V1PARC-OTNCUSTO ,
            :V1PARC-OTNIOF ,
            :V1PARC-OTNTOTAL
            FROM SEGUROS.V1PARCELA
            WHERE NUM_APOLICE = :V1HISP-NUM-APOL
            AND NRENDOS = :V1HISP-NRENDOS
            AND NRPARCEL = :V1HISP-NRPARCEL
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE 
							,
											NRENDOS 
							,
											NRPARCEL 
							,
											PRM_TARIFARIO_IX 
							,
											VAL_DESCONTO_IX 
							,
											OTNPRLIQ 
							,
											OTNADFRA 
							,
											OTNCUSTO 
							,
											OTNIOF 
							,
											OTNTOTAL
											FROM SEGUROS.V1PARCELA
											WHERE NUM_APOLICE = '{this.V1HISP_NUM_APOL}'
											AND NRENDOS = '{this.V1HISP_NRENDOS}'
											AND NRPARCEL = '{this.V1HISP_NRPARCEL}'";

            return query;
        }
        public string V1PARC_NUM_APOL { get; set; }
        public string V1PARC_NRENDOS { get; set; }
        public string V1PARC_NRPARCEL { get; set; }
        public string V1PARC_PRM_TAR { get; set; }
        public string V1PARC_VAL_DESC { get; set; }
        public string V1PARC_OTNPRLIQ { get; set; }
        public string V1PARC_OTNADFRA { get; set; }
        public string V1PARC_OTNCUSTO { get; set; }
        public string V1PARC_OTNIOF { get; set; }
        public string V1PARC_OTNTOTAL { get; set; }
        public string V1HISP_NUM_APOL { get; set; }
        public string V1HISP_NRPARCEL { get; set; }
        public string V1HISP_NRENDOS { get; set; }

        public static R3400_00_SELECT_V1PARCELA_DB_SELECT_1_Query1 Execute(R3400_00_SELECT_V1PARCELA_DB_SELECT_1_Query1 r3400_00_SELECT_V1PARCELA_DB_SELECT_1_Query1)
        {
            var ths = r3400_00_SELECT_V1PARCELA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3400_00_SELECT_V1PARCELA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3400_00_SELECT_V1PARCELA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1PARC_NUM_APOL = result[i++].Value?.ToString();
            dta.V1PARC_NRENDOS = result[i++].Value?.ToString();
            dta.V1PARC_NRPARCEL = result[i++].Value?.ToString();
            dta.V1PARC_PRM_TAR = result[i++].Value?.ToString();
            dta.V1PARC_VAL_DESC = result[i++].Value?.ToString();
            dta.V1PARC_OTNPRLIQ = result[i++].Value?.ToString();
            dta.V1PARC_OTNADFRA = result[i++].Value?.ToString();
            dta.V1PARC_OTNCUSTO = result[i++].Value?.ToString();
            dta.V1PARC_OTNIOF = result[i++].Value?.ToString();
            dta.V1PARC_OTNTOTAL = result[i++].Value?.ToString();
            return dta;
        }

    }
}