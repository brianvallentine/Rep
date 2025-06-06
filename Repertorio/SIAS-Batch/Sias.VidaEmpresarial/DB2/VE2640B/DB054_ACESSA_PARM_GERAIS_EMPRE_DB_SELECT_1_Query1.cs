using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE2640B
{
    public class DB054_ACESSA_PARM_GERAIS_EMPRE_DB_SELECT_1_Query1 : QueryBasis<DB054_ACESSA_PARM_GERAIS_EMPRE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_CORRETOR,
            PCCOMCOR,
            COD_MOEDA_FAT
            INTO :PARGEREM-COD-CORRETOR,
            :PARGEREM-PCCOMCOR,
            :PARGEREM-COD-MOEDA-FAT
            FROM SEGUROS.PARM_GERAIS_EMPRES
            WHERE NUM_APOLICE = :PARGEREM-NUM-APOLICE
            ORDER BY COD_CORRETOR DESC
            FETCH FIRST 1 ROW ONLY
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT COD_CORRETOR
							,
											PCCOMCOR
							,
											COD_MOEDA_FAT
											FROM SEGUROS.PARM_GERAIS_EMPRES
											WHERE NUM_APOLICE = '{this.PARGEREM_NUM_APOLICE}'
											ORDER BY COD_CORRETOR DESC
											FETCH FIRST 1 ROW ONLY";

            return query;
        }
        public string PARGEREM_COD_CORRETOR { get; set; }
        public string PARGEREM_PCCOMCOR { get; set; }
        public string PARGEREM_COD_MOEDA_FAT { get; set; }
        public string PARGEREM_NUM_APOLICE { get; set; }

        public static DB054_ACESSA_PARM_GERAIS_EMPRE_DB_SELECT_1_Query1 Execute(DB054_ACESSA_PARM_GERAIS_EMPRE_DB_SELECT_1_Query1 dB054_ACESSA_PARM_GERAIS_EMPRE_DB_SELECT_1_Query1)
        {
            var ths = dB054_ACESSA_PARM_GERAIS_EMPRE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override DB054_ACESSA_PARM_GERAIS_EMPRE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new DB054_ACESSA_PARM_GERAIS_EMPRE_DB_SELECT_1_Query1();
            var i = 0;
            dta.PARGEREM_COD_CORRETOR = result[i++].Value?.ToString();
            dta.PARGEREM_PCCOMCOR = result[i++].Value?.ToString();
            dta.PARGEREM_COD_MOEDA_FAT = result[i++].Value?.ToString();
            return dta;
        }

    }
}