using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0601B
{
    public class R5635_00_UPDATE_PROPOSTAVA_DB_UPDATE_1_Update1 : QueryBasis<R5635_00_UPDATE_PROPOSTAVA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PROPOSTAS_VA
				SET COD_CLIENTE =
				 '{this.COD_CLIENTE}' ,
				OCOREND =
				 '{this.ENDERECO_OCORR_ENDERECO}',
				COD_FONTE =
				 '{this.WHOST_FONTE}' ,
				PROFISSAO =
				 '{this.WHOST_PROFISSAO}' ,
				SIT_REGISTRO =
				 '{this.WHOST_SIT_REGISTRO}' ,
				DTPROXVEN =
				 '{this.WHOST_DTPROXVEN}' ,
				IDADE =
				 '{this.WHOST_IDADE}' ,
				NOME_ESPOSA =
				 {FieldThreatment((this.VIND_NOME_CONJUGE?.ToInt() == -1 ? null : $"{this.PROPOFID_NOME_CONJUGE}"))} ,
				DTNASC_ESPOSA =
				 {FieldThreatment((this.VIND_DATA_NASC_CONJUGE?.ToInt() == -1 ? null : $"{this.PROPOFID_DATA_NASC_CONJUGE}"))} ,
				PROFIS_ESPOSA =
				 {FieldThreatment((this.VIND_PROFISSAO_CONJUGE?.ToInt() == -1 ? null : $"{this.WHOST_PROFISSAO_CONJUGE}"))} ,
				INFO_COMPLEMENTAR =
				 '{this.WHOST_INFO_COMPL}' ,
				COD_CCT =
				 {FieldThreatment((this.VIND_CGC_CONVENENTE?.ToInt() == -1 ? null : $"{this.PROPOFID_CGC_CONVENENTE}"))} ,
				NUM_CONTR_VINCULO =
				 {FieldThreatment((this.VIND_NUM_CONTR?.ToInt() == -1 ? null : $"{this.PROPSSVD_NUM_CONTR_VINCULO}"))} ,
				COD_CORRESP_BANC =
				 {FieldThreatment((this.VIND_COD_CORRESP?.ToInt() == -1 ? null : $"{this.PROPSSVD_COD_CORRESP_BANC}"))} ,
				COD_ORIGEM_PROPOSTA =
				 '{this.PROPOFID_ORIGEM_PROPOSTA}' ,
				NUM_PRAZO_FIN =
				 {FieldThreatment((this.VIND_NUM_PRAZO?.ToInt() == -1 ? null : $"{this.PROPSSVD_NUM_PRAZO_FIN}"))} ,
				COD_OPER_CREDITO =
				 {FieldThreatment((this.VIND_COD_OPER_CRED?.ToInt() == -1 ? null : $"{this.PROPSSVD_COD_OPER_CREDITO}"))} ,
				DTA_DECLINIO =
				 {FieldThreatment((this.VIND_DATA_DECLINIO?.ToInt() == -1 ? null : $"{this.SISTEMAS_DATA_MOV_ABERTO}"))}
				WHERE 
				NUM_CERTIFICADO =
				 '{this.PROPOFID_NUM_PROPOSTA_SIVPF}'";

            return query;
        }
        public string PROPOFID_DATA_NASC_CONJUGE { get; set; }
        public string VIND_DATA_NASC_CONJUGE { get; set; }
        public string PROPOFID_CGC_CONVENENTE { get; set; }
        public string VIND_CGC_CONVENENTE { get; set; }
        public string PROPOFID_NOME_CONJUGE { get; set; }
        public string VIND_NOME_CONJUGE { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string VIND_DATA_DECLINIO { get; set; }
        public string WHOST_PROFISSAO_CONJUGE { get; set; }
        public string VIND_PROFISSAO_CONJUGE { get; set; }
        public string PROPSSVD_COD_OPER_CREDITO { get; set; }
        public string VIND_COD_OPER_CRED { get; set; }
        public string PROPSSVD_COD_CORRESP_BANC { get; set; }
        public string VIND_COD_CORRESP { get; set; }
        public string PROPSSVD_NUM_CONTR_VINCULO { get; set; }
        public string VIND_NUM_CONTR { get; set; }
        public string PROPSSVD_NUM_PRAZO_FIN { get; set; }
        public string VIND_NUM_PRAZO { get; set; }
        public string ENDERECO_OCORR_ENDERECO { get; set; }
        public string PROPOFID_ORIGEM_PROPOSTA { get; set; }
        public string COD_CLIENTE { get; set; }
        public string WHOST_SIT_REGISTRO { get; set; }
        public string WHOST_INFO_COMPL { get; set; }
        public string WHOST_PROFISSAO { get; set; }
        public string WHOST_DTPROXVEN { get; set; }
        public string WHOST_FONTE { get; set; }
        public string WHOST_IDADE { get; set; }
        public string PROPOFID_NUM_PROPOSTA_SIVPF { get; set; }

        public static void Execute(R5635_00_UPDATE_PROPOSTAVA_DB_UPDATE_1_Update1 r5635_00_UPDATE_PROPOSTAVA_DB_UPDATE_1_Update1)
        {
            var ths = r5635_00_UPDATE_PROPOSTAVA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R5635_00_UPDATE_PROPOSTAVA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}