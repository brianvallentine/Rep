using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0106B
{
    public class R0290_GERAR_TAB_PAGAMENTO_DB_INSERT_1_Insert1 : QueryBasis<R0290_GERAR_TAB_PAGAMENTO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.PF_PGTO_SIVPF VALUES
            (:PF038-NUM-TITULO-SIVPF ,
            :PF038-COD-PRODUTO-SIVPF,
            :PF038-COD-AGENCIA ,
            :PF038-IND-PAGAMENTO ,
            :PF038-NUM-CGC-CPF ,
            :PF038-NUM-PROPOSTA ,
            :PF038-NUM-CERTIFICADO ,
            :PF038-NUM-PARCELA-PAGA ,
            :PF038-DTH-QUITACAO ,
            :PF038-VLR-PAGO ,
            :PF038-SIGLA-ARQUIVO ,
            :PF038-SISTEMA-ORIGEM ,
            :PF038-NSAS-SIVPF)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.PF_PGTO_SIVPF VALUES ({FieldThreatment(this.PF038_NUM_TITULO_SIVPF)} , {FieldThreatment(this.PF038_COD_PRODUTO_SIVPF)}, {FieldThreatment(this.PF038_COD_AGENCIA)} , {FieldThreatment(this.PF038_IND_PAGAMENTO)} , {FieldThreatment(this.PF038_NUM_CGC_CPF)} , {FieldThreatment(this.PF038_NUM_PROPOSTA)} , {FieldThreatment(this.PF038_NUM_CERTIFICADO)} , {FieldThreatment(this.PF038_NUM_PARCELA_PAGA)} , {FieldThreatment(this.PF038_DTH_QUITACAO)} , {FieldThreatment(this.PF038_VLR_PAGO)} , {FieldThreatment(this.PF038_SIGLA_ARQUIVO)} , {FieldThreatment(this.PF038_SISTEMA_ORIGEM)} , {FieldThreatment(this.PF038_NSAS_SIVPF)})";

            return query;
        }
        public string PF038_NUM_TITULO_SIVPF { get; set; }
        public string PF038_COD_PRODUTO_SIVPF { get; set; }
        public string PF038_COD_AGENCIA { get; set; }
        public string PF038_IND_PAGAMENTO { get; set; }
        public string PF038_NUM_CGC_CPF { get; set; }
        public string PF038_NUM_PROPOSTA { get; set; }
        public string PF038_NUM_CERTIFICADO { get; set; }
        public string PF038_NUM_PARCELA_PAGA { get; set; }
        public string PF038_DTH_QUITACAO { get; set; }
        public string PF038_VLR_PAGO { get; set; }
        public string PF038_SIGLA_ARQUIVO { get; set; }
        public string PF038_SISTEMA_ORIGEM { get; set; }
        public string PF038_NSAS_SIVPF { get; set; }

        public static void Execute(R0290_GERAR_TAB_PAGAMENTO_DB_INSERT_1_Insert1 r0290_GERAR_TAB_PAGAMENTO_DB_INSERT_1_Insert1)
        {
            var ths = r0290_GERAR_TAB_PAGAMENTO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0290_GERAR_TAB_PAGAMENTO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}