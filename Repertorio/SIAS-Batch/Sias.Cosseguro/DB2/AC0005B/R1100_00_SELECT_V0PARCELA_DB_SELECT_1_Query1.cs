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
    public class R1100_00_SELECT_V0PARCELA_DB_SELECT_1_Query1 : QueryBasis<R1100_00_SELECT_V0PARCELA_DB_SELECT_1_Query1>
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
            INTO :V0PARC-NUM-APOL ,
            :V0PARC-NRENDOS ,
            :V0PARC-NRPARCEL ,
            :V0PARC-PRM-TAR ,
            :V0PARC-VAL-DESC ,
            :V0PARC-OTNPRLIQ ,
            :V0PARC-OTNADFRA ,
            :V0PARC-OTNCUSTO ,
            :V0PARC-OTNIOF ,
            :V0PARC-OTNTOTAL
            FROM SEGUROS.V0PARCELA
            WHERE NUM_APOLICE = :V0HISP-NUM-APOL
            AND NRENDOS = :V0HISP-NRENDOS
            AND NRPARCEL = :V0HISP-NRPARCEL
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
											FROM SEGUROS.V0PARCELA
											WHERE NUM_APOLICE = '{this.V0HISP_NUM_APOL}'
											AND NRENDOS = '{this.V0HISP_NRENDOS}'
											AND NRPARCEL = '{this.V0HISP_NRPARCEL}'";

            return query;
        }
        public string V0PARC_NUM_APOL { get; set; }
        public string V0PARC_NRENDOS { get; set; }
        public string V0PARC_NRPARCEL { get; set; }
        public string V0PARC_PRM_TAR { get; set; }
        public string V0PARC_VAL_DESC { get; set; }
        public string V0PARC_OTNPRLIQ { get; set; }
        public string V0PARC_OTNADFRA { get; set; }
        public string V0PARC_OTNCUSTO { get; set; }
        public string V0PARC_OTNIOF { get; set; }
        public string V0PARC_OTNTOTAL { get; set; }
        public string V0HISP_NUM_APOL { get; set; }
        public string V0HISP_NRPARCEL { get; set; }
        public string V0HISP_NRENDOS { get; set; }

        public static R1100_00_SELECT_V0PARCELA_DB_SELECT_1_Query1 Execute(R1100_00_SELECT_V0PARCELA_DB_SELECT_1_Query1 r1100_00_SELECT_V0PARCELA_DB_SELECT_1_Query1)
        {
            var ths = r1100_00_SELECT_V0PARCELA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1100_00_SELECT_V0PARCELA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1100_00_SELECT_V0PARCELA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0PARC_NUM_APOL = result[i++].Value?.ToString();
            dta.V0PARC_NRENDOS = result[i++].Value?.ToString();
            dta.V0PARC_NRPARCEL = result[i++].Value?.ToString();
            dta.V0PARC_PRM_TAR = result[i++].Value?.ToString();
            dta.V0PARC_VAL_DESC = result[i++].Value?.ToString();
            dta.V0PARC_OTNPRLIQ = result[i++].Value?.ToString();
            dta.V0PARC_OTNADFRA = result[i++].Value?.ToString();
            dta.V0PARC_OTNCUSTO = result[i++].Value?.ToString();
            dta.V0PARC_OTNIOF = result[i++].Value?.ToString();
            dta.V0PARC_OTNTOTAL = result[i++].Value?.ToString();
            return dta;
        }

    }
}