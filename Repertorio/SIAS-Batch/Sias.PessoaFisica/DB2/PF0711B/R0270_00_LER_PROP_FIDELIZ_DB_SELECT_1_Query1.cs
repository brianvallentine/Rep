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
    public class R0270_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1 : QueryBasis<R0270_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_IDENTIFICACAO,
            COD_EMPRESA_SIVPF,
            COD_PRODUTO_SIVPF,
            SIT_PROPOSTA ,
            DTQITBCO ,
            VAL_PAGO ,
            AGEPGTO ,
            DATA_CREDITO
            INTO :DCLPROPOSTA-FIDELIZ.NUM-IDENTIFICACAO,
            :DCLPROPOSTA-FIDELIZ.COD-EMPRESA-SIVPF,
            :DCLPROPOSTA-FIDELIZ.COD-PRODUTO-SIVPF,
            :DCLPROPOSTA-FIDELIZ.SIT-PROPOSTA ,
            :DCLPROPOSTA-FIDELIZ.DTQITBCO ,
            :DCLPROPOSTA-FIDELIZ.VAL-PAGO ,
            :DCLPROPOSTA-FIDELIZ.AGEPGTO ,
            :DCLPROPOSTA-FIDELIZ.DATA-CREDITO
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
							,
											SIT_PROPOSTA 
							,
											DTQITBCO 
							,
											VAL_PAGO 
							,
											AGEPGTO 
							,
											DATA_CREDITO
											FROM SEGUROS.PROPOSTA_FIDELIZ
											WHERE NUM_PROPOSTA_SIVPF =
											'{this.NUM_PROPOSTA_SIVPF}'
											WITH UR";

            return query;
        }
        public string NUM_IDENTIFICACAO { get; set; }
        public string COD_EMPRESA_SIVPF { get; set; }
        public string COD_PRODUTO_SIVPF { get; set; }
        public string SIT_PROPOSTA { get; set; }
        public string DTQITBCO { get; set; }
        public string VAL_PAGO { get; set; }
        public string AGEPGTO { get; set; }
        public string DATA_CREDITO { get; set; }
        public string NUM_PROPOSTA_SIVPF { get; set; }

        public static R0270_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1 Execute(R0270_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1 r0270_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1)
        {
            var ths = r0270_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0270_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0270_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1();
            var i = 0;
            dta.NUM_IDENTIFICACAO = result[i++].Value?.ToString();
            dta.COD_EMPRESA_SIVPF = result[i++].Value?.ToString();
            dta.COD_PRODUTO_SIVPF = result[i++].Value?.ToString();
            dta.SIT_PROPOSTA = result[i++].Value?.ToString();
            dta.DTQITBCO = result[i++].Value?.ToString();
            dta.VAL_PAGO = result[i++].Value?.ToString();
            dta.AGEPGTO = result[i++].Value?.ToString();
            dta.DATA_CREDITO = result[i++].Value?.ToString();
            return dta;
        }

    }
}