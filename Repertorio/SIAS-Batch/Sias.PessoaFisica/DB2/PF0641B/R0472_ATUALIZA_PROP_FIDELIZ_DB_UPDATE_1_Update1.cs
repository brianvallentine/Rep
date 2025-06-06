using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0641B
{
    public class R0472_ATUALIZA_PROP_FIDELIZ_DB_UPDATE_1_Update1 : QueryBasis<R0472_ATUALIZA_PROP_FIDELIZ_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PROPOSTA_FIDELIZ
				SET NUM_SICOB =
				 '{this.NUM_SICOB}' ,
				DATA_PROPOSTA =
				 '{this.DATA_PROPOSTA}' ,
				COD_PRODUTO_SIVPF =
				 '{this.COD_PRODUTO_SIVPF}' ,
				AGECOBR =
				 '{this.AGECOBR}' ,
				DIA_DEBITO =
				 '{this.DIA_DEBITO}' ,
				OPCAOPAG =
				 '{this.OPCAOPAG}' ,
				AGECTADEB =
				 '{this.AGECTADEB}' ,
				OPRCTADEB =
				 '{this.OPRCTADEB}' ,
				NUMCTADEB =
				 '{this.NUMCTADEB}' ,
				DIGCTADEB =
				 '{this.DIGCTADEB}' ,
				PERC_DESCONTO =
				 '{this.PERC_DESCONTO}' ,
				NRMATRVEN =
				 '{this.NRMATRVEN}' ,
				AGECTAVEN =
				 '{this.AGECTAVEN}' ,
				OPRCTAVEN =
				 '{this.OPRCTAVEN}' ,
				NUMCTAVEN =
				 '{this.NUMCTAVEN}' ,
				DIGCTAVEN =
				 '{this.DIGCTAVEN}' ,
				CGC_CONVENENTE =
				 '{this.CGC_CONVENENTE}' ,
				NOME_CONVENENTE =
				 '{this.NOME_CONVENENTE}' ,
				NRMATRCON =
				 '{this.NRMATRCON}' ,
				DTQITBCO =
				 '{this.DTQITBCO}' ,
				VAL_PAGO =
				 '{this.VAL_PAGO}' ,
				AGEPGTO =
				 '{this.AGEPGTO}' ,
				DATA_CREDITO =
				 '{this.DATA_CREDITO}' ,
				SIT_PROPOSTA =
				 '{this.SIT_PROPOSTA}' ,
				COD_USUARIO =
				 '{this.COD_USUARIO}' ,
				TIMESTAMP =
				CURRENT TIMESTAMP ,
				NSL =
				 '{this.NSL}' ,
				NSAC_SIVPF =
				 '{this.NSAC_SIVPF}' ,
				SITUACAO_ENVIO =
				 '{this.SITUACAO_ENVIO}' ,
				OPCAO_COBER =
				 '{this.OPCAO_COBER}' ,
				COD_PLANO =
				 '{this.COD_PLANO}'
				WHERE  NUM_PROPOSTA_SIVPF =
				 '{this.NUM_PROPOSTA_SIVPF}'";

            return query;
        }
        public string COD_PRODUTO_SIVPF { get; set; }
        public string NOME_CONVENENTE { get; set; }
        public string CGC_CONVENENTE { get; set; }
        public string SITUACAO_ENVIO { get; set; }
        public string DATA_PROPOSTA { get; set; }
        public string PERC_DESCONTO { get; set; }
        public string DATA_CREDITO { get; set; }
        public string SIT_PROPOSTA { get; set; }
        public string COD_USUARIO { get; set; }
        public string OPCAO_COBER { get; set; }
        public string DIA_DEBITO { get; set; }
        public string NSAC_SIVPF { get; set; }
        public string NUM_SICOB { get; set; }
        public string AGECTADEB { get; set; }
        public string OPRCTADEB { get; set; }
        public string NUMCTADEB { get; set; }
        public string DIGCTADEB { get; set; }
        public string NRMATRVEN { get; set; }
        public string AGECTAVEN { get; set; }
        public string OPRCTAVEN { get; set; }
        public string NUMCTAVEN { get; set; }
        public string DIGCTAVEN { get; set; }
        public string NRMATRCON { get; set; }
        public string COD_PLANO { get; set; }
        public string OPCAOPAG { get; set; }
        public string DTQITBCO { get; set; }
        public string VAL_PAGO { get; set; }
        public string AGECOBR { get; set; }
        public string AGEPGTO { get; set; }
        public string NSL { get; set; }
        public string NUM_PROPOSTA_SIVPF { get; set; }

        public static void Execute(R0472_ATUALIZA_PROP_FIDELIZ_DB_UPDATE_1_Update1 r0472_ATUALIZA_PROP_FIDELIZ_DB_UPDATE_1_Update1)
        {
            var ths = r0472_ATUALIZA_PROP_FIDELIZ_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0472_ATUALIZA_PROP_FIDELIZ_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}