using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0602B
{
    public class R3002_01_ESQ_DEBITO_CARTAO_DB_SELECT_1_Query1 : QueryBasis<R3002_01_ESQ_DEBITO_CARTAO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_CARTAO_CREDITO
            INTO :OPPAGVA-NUM-CARTAO-CREDITO
            FROM SEGUROS.OPCAO_PAG_VIDAZUL
            WHERE NUM_CERTIFICADO = :OPPAGVA-NUM-CERTIFICADO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_CARTAO_CREDITO
											FROM SEGUROS.OPCAO_PAG_VIDAZUL
											WHERE NUM_CERTIFICADO = '{this.OPPAGVA_NUM_CERTIFICADO}'
											WITH UR";

            return query;
        }
        public string OPPAGVA_NUM_CARTAO_CREDITO { get; set; }
        public string OPPAGVA_NUM_CERTIFICADO { get; set; }

        public static R3002_01_ESQ_DEBITO_CARTAO_DB_SELECT_1_Query1 Execute(R3002_01_ESQ_DEBITO_CARTAO_DB_SELECT_1_Query1 r3002_01_ESQ_DEBITO_CARTAO_DB_SELECT_1_Query1)
        {
            var ths = r3002_01_ESQ_DEBITO_CARTAO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3002_01_ESQ_DEBITO_CARTAO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3002_01_ESQ_DEBITO_CARTAO_DB_SELECT_1_Query1();
            var i = 0;
            dta.OPPAGVA_NUM_CARTAO_CREDITO = result[i++].Value?.ToString();
            return dta;
        }

    }
}