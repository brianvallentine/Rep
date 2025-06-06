using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0402B
{
    public class R0110_00_SELECT_PROP_FID_DB_SELECT_1_Query1 : QueryBasis<R0110_00_SELECT_PROP_FID_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_PRODUTO_SIVPF,
            COD_PESSOA,
            NUM_IDENTIFICACAO,
            SIT_PROPOSTA,
            NSAS_SIVPF
            INTO :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PRODUTO-SIVPF,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PESSOA,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-IDENTIFICACAO,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-SIT-PROPOSTA,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-NSAS-SIVPF
            FROM SEGUROS.PROPOSTA_FIDELIZ
            WHERE NUM_PROPOSTA_SIVPF =
            :DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_PRODUTO_SIVPF
							,
											COD_PESSOA
							,
											NUM_IDENTIFICACAO
							,
											SIT_PROPOSTA
							,
											NSAS_SIVPF
											FROM SEGUROS.PROPOSTA_FIDELIZ
											WHERE NUM_PROPOSTA_SIVPF =
											'{this.PROPOFID_NUM_PROPOSTA_SIVPF}'
											WITH UR";

            return query;
        }
        public string PROPOFID_COD_PRODUTO_SIVPF { get; set; }
        public string PROPOFID_COD_PESSOA { get; set; }
        public string PROPOFID_NUM_IDENTIFICACAO { get; set; }
        public string PROPOFID_SIT_PROPOSTA { get; set; }
        public string PROPOFID_NSAS_SIVPF { get; set; }
        public string PROPOFID_NUM_PROPOSTA_SIVPF { get; set; }

        public static R0110_00_SELECT_PROP_FID_DB_SELECT_1_Query1 Execute(R0110_00_SELECT_PROP_FID_DB_SELECT_1_Query1 r0110_00_SELECT_PROP_FID_DB_SELECT_1_Query1)
        {
            var ths = r0110_00_SELECT_PROP_FID_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0110_00_SELECT_PROP_FID_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0110_00_SELECT_PROP_FID_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPOFID_COD_PRODUTO_SIVPF = result[i++].Value?.ToString();
            dta.PROPOFID_COD_PESSOA = result[i++].Value?.ToString();
            dta.PROPOFID_NUM_IDENTIFICACAO = result[i++].Value?.ToString();
            dta.PROPOFID_SIT_PROPOSTA = result[i++].Value?.ToString();
            dta.PROPOFID_NSAS_SIVPF = result[i++].Value?.ToString();
            return dta;
        }

    }
}