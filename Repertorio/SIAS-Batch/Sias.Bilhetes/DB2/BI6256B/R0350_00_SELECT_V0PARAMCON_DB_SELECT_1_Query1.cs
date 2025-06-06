using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI6256B
{
    public class R0350_00_SELECT_V0PARAMCON_DB_SELECT_1_Query1 : QueryBasis<R0350_00_SELECT_V0PARAMCON_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT TIPO_MOVTO_CC ,
            COD_PRODUTO ,
            COD_CONVENIO ,
            NSAS
            INTO :PARAMCON-TIPO-MOVTO-CC ,
            :PARAMCON-COD-PRODUTO ,
            :PARAMCON-COD-CONVENIO ,
            :PARAMCON-NSAS
            FROM SEGUROS.PARAM_CONTACEF
            WHERE TIPO_MOVTO_CC = :PARAMCON-TIPO-MOVTO-CC
            AND COD_PRODUTO = :PARAMCON-COD-PRODUTO
            AND COD_CONVENIO = :PARAMCON-COD-CONVENIO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT TIPO_MOVTO_CC 
							,
											COD_PRODUTO 
							,
											COD_CONVENIO 
							,
											NSAS
											FROM SEGUROS.PARAM_CONTACEF
											WHERE TIPO_MOVTO_CC = '{this.PARAMCON_TIPO_MOVTO_CC}'
											AND COD_PRODUTO = '{this.PARAMCON_COD_PRODUTO}'
											AND COD_CONVENIO = '{this.PARAMCON_COD_CONVENIO}'
											WITH UR";

            return query;
        }
        public string PARAMCON_TIPO_MOVTO_CC { get; set; }
        public string PARAMCON_COD_PRODUTO { get; set; }
        public string PARAMCON_COD_CONVENIO { get; set; }
        public string PARAMCON_NSAS { get; set; }

        public static R0350_00_SELECT_V0PARAMCON_DB_SELECT_1_Query1 Execute(R0350_00_SELECT_V0PARAMCON_DB_SELECT_1_Query1 r0350_00_SELECT_V0PARAMCON_DB_SELECT_1_Query1)
        {
            var ths = r0350_00_SELECT_V0PARAMCON_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0350_00_SELECT_V0PARAMCON_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0350_00_SELECT_V0PARAMCON_DB_SELECT_1_Query1();
            var i = 0;
            dta.PARAMCON_TIPO_MOVTO_CC = result[i++].Value?.ToString();
            dta.PARAMCON_COD_PRODUTO = result[i++].Value?.ToString();
            dta.PARAMCON_COD_CONVENIO = result[i++].Value?.ToString();
            dta.PARAMCON_NSAS = result[i++].Value?.ToString();
            return dta;
        }

    }
}