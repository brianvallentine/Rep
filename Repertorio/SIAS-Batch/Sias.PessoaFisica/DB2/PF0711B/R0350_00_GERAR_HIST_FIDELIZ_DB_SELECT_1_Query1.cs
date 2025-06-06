using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0711B
{
    public class R0350_00_GERAR_HIST_FIDELIZ_DB_SELECT_1_Query1 : QueryBasis<R0350_00_GERAR_HIST_FIDELIZ_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_IDENTIFICACAO,
            COD_EMPRESA_SIVPF,
            COD_PRODUTO_SIVPF
            INTO :PROPFIDH-NUM-IDENTIFICACAO ,
            :PROPFIDH-COD-EMPRESA-SIVPF ,
            :PROPFIDH-COD-PRODUTO-SIVPF
            FROM SEGUROS.PROPOSTA_FIDELIZ
            WHERE NUM_PROPOSTA_SIVPF =
            :DCLPROPOSTA-FIDELIZ.NUM-PROPOSTA-SIVPF
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_IDENTIFICACAO
							,
											COD_EMPRESA_SIVPF
							,
											COD_PRODUTO_SIVPF
											FROM SEGUROS.PROPOSTA_FIDELIZ
											WHERE NUM_PROPOSTA_SIVPF =
											'{this.NUM_PROPOSTA_SIVPF}'
											WITH UR";

            return query;
        }
        public string PROPFIDH_NUM_IDENTIFICACAO { get; set; }
        public string PROPFIDH_COD_EMPRESA_SIVPF { get; set; }
        public string PROPFIDH_COD_PRODUTO_SIVPF { get; set; }
        public string NUM_PROPOSTA_SIVPF { get; set; }

        public static R0350_00_GERAR_HIST_FIDELIZ_DB_SELECT_1_Query1 Execute(R0350_00_GERAR_HIST_FIDELIZ_DB_SELECT_1_Query1 r0350_00_GERAR_HIST_FIDELIZ_DB_SELECT_1_Query1)
        {
            var ths = r0350_00_GERAR_HIST_FIDELIZ_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0350_00_GERAR_HIST_FIDELIZ_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0350_00_GERAR_HIST_FIDELIZ_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPFIDH_NUM_IDENTIFICACAO = result[i++].Value?.ToString();
            dta.PROPFIDH_COD_EMPRESA_SIVPF = result[i++].Value?.ToString();
            dta.PROPFIDH_COD_PRODUTO_SIVPF = result[i++].Value?.ToString();
            return dta;
        }

    }
}