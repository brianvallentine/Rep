using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE0414B
{
    public class R1400_00_SELECT_PERIPGTO_DB_SELECT_1_Query1 : QueryBasis<R1400_00_SELECT_PERIPGTO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PERI_PAGAMENTO
            INTO :OPCPAGVI-PERI-PAGAMENTO
            FROM SEGUROS.OPCAO_PAG_VIDAZUL
            WHERE NUM_CERTIFICADO = :RELATORI-NUM-TITULO
            AND DATA_TERVIGENCIA IN ( '1999-12-31' , '9999-12-31' )
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PERI_PAGAMENTO
											FROM SEGUROS.OPCAO_PAG_VIDAZUL
											WHERE NUM_CERTIFICADO = '{this.RELATORI_NUM_TITULO}'
											AND DATA_TERVIGENCIA IN ( '1999-12-31' 
							, '9999-12-31' )";

            return query;
        }
        public string OPCPAGVI_PERI_PAGAMENTO { get; set; }
        public string RELATORI_NUM_TITULO { get; set; }

        public static R1400_00_SELECT_PERIPGTO_DB_SELECT_1_Query1 Execute(R1400_00_SELECT_PERIPGTO_DB_SELECT_1_Query1 r1400_00_SELECT_PERIPGTO_DB_SELECT_1_Query1)
        {
            var ths = r1400_00_SELECT_PERIPGTO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1400_00_SELECT_PERIPGTO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1400_00_SELECT_PERIPGTO_DB_SELECT_1_Query1();
            var i = 0;
            dta.OPCPAGVI_PERI_PAGAMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}