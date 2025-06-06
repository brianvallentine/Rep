using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2646B
{
    public class R1920_00_INSERT_PROPOFID_DB_INSERT_1_Insert1 : QueryBasis<R1920_00_INSERT_PROPOFID_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.PROPOSTA_FIDELIZ
            ( NUM_PROPOSTA_SIVPF ,
            NUM_IDENTIFICACAO ,
            COD_EMPRESA_SIVPF ,
            COD_PESSOA ,
            NUM_SICOB ,
            DATA_PROPOSTA ,
            COD_PRODUTO_SIVPF ,
            AGECOBR ,
            DIA_DEBITO ,
            OPCAOPAG ,
            AGECTADEB ,
            OPRCTADEB ,
            NUMCTADEB ,
            DIGCTADEB ,
            PERC_DESCONTO ,
            NRMATRVEN ,
            AGECTAVEN ,
            OPRCTAVEN ,
            NUMCTAVEN ,
            DIGCTAVEN ,
            CGC_CONVENENTE ,
            NOME_CONVENENTE ,
            NRMATRCON ,
            DTQITBCO ,
            VAL_PAGO ,
            AGEPGTO ,
            VAL_TARIFA ,
            VAL_IOF ,
            DATA_CREDITO ,
            VAL_COMISSAO ,
            SIT_PROPOSTA ,
            COD_USUARIO ,
            CANAL_PROPOSTA ,
            NSAS_SIVPF ,
            ORIGEM_PROPOSTA ,
            TIMESTAMP ,
            NSL ,
            NSAC_SIVPF ,
            SITUACAO_ENVIO ,
            OPCAO_COBER ,
            COD_PLANO ,
            NOME_CONJUGE ,
            DATA_NASC_CONJUGE ,
            PROFISSAO_CONJUGE ,
            FAIXA_RENDA_IND ,
            FAIXA_RENDA_FAM ,
            IND_TIPO_CONTA
            )
            VALUES
            (
            :PROPOFID-NUM-PROPOSTA-SIVPF ,
            :PROPOFID-NUM-IDENTIFICACAO ,
            :PROPOFID-COD-EMPRESA-SIVPF ,
            :PESSOA-COD-PESSOA ,
            :PROPOFID-NUM-SICOB ,
            :PROPOFID-DATA-PROPOSTA ,
            :PROPOFID-COD-PRODUTO-SIVPF ,
            :PROPOFID-AGECOBR ,
            :PROPOFID-DIA-DEBITO ,
            :PROPOFID-OPCAOPAG ,
            :PROPOFID-AGECTADEB ,
            :PROPOFID-OPRCTADEB ,
            :PROPOFID-NUMCTADEB ,
            :PROPOFID-DIGCTADEB ,
            :PROPOFID-PERC-DESCONTO ,
            :PROPOFID-NRMATRVEN ,
            :PROPOFID-AGECTAVEN ,
            :PROPOFID-OPRCTAVEN ,
            :PROPOFID-NUMCTAVEN ,
            :PROPOFID-DIGCTAVEN ,
            :PROPOFID-CGC-CONVENENTE ,
            :PROPOFID-NOME-CONVENENTE ,
            :PROPOFID-NRMATRCON ,
            :PROPOFID-DTQITBCO ,
            :PROPOFID-VAL-PAGO ,
            :PROPOFID-AGEPGTO ,
            :PROPOFID-VAL-TARIFA ,
            :PROPOFID-VAL-IOF ,
            :PROPOFID-DATA-CREDITO ,
            :PROPOFID-VAL-COMISSAO ,
            :PROPOFID-SIT-PROPOSTA ,
            :PROPOFID-COD-USUARIO ,
            :PROPOFID-CANAL-PROPOSTA ,
            :PROPOFID-NSAS-SIVPF ,
            :PROPOFID-ORIGEM-PROPOSTA ,
            CURRENT TIMESTAMP ,
            :PROPOFID-NSL ,
            :PROPOFID-NSAC-SIVPF ,
            :PROPOFID-SITUACAO-ENVIO ,
            :PROPOFID-OPCAO-COBER ,
            :PROPOFID-COD-PLANO ,
            :PROPOFID-NOME-CONJUGE :VIND-NULL,
            :PROPOFID-DATA-NASC-CONJUGE :VIND-NULL,
            :PROPOFID-PROFISSAO-CONJUGE :VIND-NULL,
            :PROPOFID-FAIXA-RENDA-IND :VIND-NULL,
            :PROPOFID-FAIXA-RENDA-FAM :VIND-NULL,
            :PROPOFID-IND-TIPO-CONTA
            )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.PROPOSTA_FIDELIZ ( NUM_PROPOSTA_SIVPF , NUM_IDENTIFICACAO , COD_EMPRESA_SIVPF , COD_PESSOA , NUM_SICOB , DATA_PROPOSTA , COD_PRODUTO_SIVPF , AGECOBR , DIA_DEBITO , OPCAOPAG , AGECTADEB , OPRCTADEB , NUMCTADEB , DIGCTADEB , PERC_DESCONTO , NRMATRVEN , AGECTAVEN , OPRCTAVEN , NUMCTAVEN , DIGCTAVEN , CGC_CONVENENTE , NOME_CONVENENTE , NRMATRCON , DTQITBCO , VAL_PAGO , AGEPGTO , VAL_TARIFA , VAL_IOF , DATA_CREDITO , VAL_COMISSAO , SIT_PROPOSTA , COD_USUARIO , CANAL_PROPOSTA , NSAS_SIVPF , ORIGEM_PROPOSTA , TIMESTAMP , NSL , NSAC_SIVPF , SITUACAO_ENVIO , OPCAO_COBER , COD_PLANO , NOME_CONJUGE , DATA_NASC_CONJUGE , PROFISSAO_CONJUGE , FAIXA_RENDA_IND , FAIXA_RENDA_FAM , IND_TIPO_CONTA ) VALUES ( {FieldThreatment(this.PROPOFID_NUM_PROPOSTA_SIVPF)} , {FieldThreatment(this.PROPOFID_NUM_IDENTIFICACAO)} , {FieldThreatment(this.PROPOFID_COD_EMPRESA_SIVPF)} , {FieldThreatment(this.PESSOA_COD_PESSOA)} , {FieldThreatment(this.PROPOFID_NUM_SICOB)} , {FieldThreatment(this.PROPOFID_DATA_PROPOSTA)} , {FieldThreatment(this.PROPOFID_COD_PRODUTO_SIVPF)} , {FieldThreatment(this.PROPOFID_AGECOBR)} , {FieldThreatment(this.PROPOFID_DIA_DEBITO)} , {FieldThreatment(this.PROPOFID_OPCAOPAG)} , {FieldThreatment(this.PROPOFID_AGECTADEB)} , {FieldThreatment(this.PROPOFID_OPRCTADEB)} , {FieldThreatment(this.PROPOFID_NUMCTADEB)} , {FieldThreatment(this.PROPOFID_DIGCTADEB)} , {FieldThreatment(this.PROPOFID_PERC_DESCONTO)} , {FieldThreatment(this.PROPOFID_NRMATRVEN)} , {FieldThreatment(this.PROPOFID_AGECTAVEN)} , {FieldThreatment(this.PROPOFID_OPRCTAVEN)} , {FieldThreatment(this.PROPOFID_NUMCTAVEN)} , {FieldThreatment(this.PROPOFID_DIGCTAVEN)} , {FieldThreatment(this.PROPOFID_CGC_CONVENENTE)} , {FieldThreatment(this.PROPOFID_NOME_CONVENENTE)} , {FieldThreatment(this.PROPOFID_NRMATRCON)} , {FieldThreatment(this.PROPOFID_DTQITBCO)} , {FieldThreatment(this.PROPOFID_VAL_PAGO)} , {FieldThreatment(this.PROPOFID_AGEPGTO)} , {FieldThreatment(this.PROPOFID_VAL_TARIFA)} , {FieldThreatment(this.PROPOFID_VAL_IOF)} , {FieldThreatment(this.PROPOFID_DATA_CREDITO)} , {FieldThreatment(this.PROPOFID_VAL_COMISSAO)} , {FieldThreatment(this.PROPOFID_SIT_PROPOSTA)} , {FieldThreatment(this.PROPOFID_COD_USUARIO)} , {FieldThreatment(this.PROPOFID_CANAL_PROPOSTA)} , {FieldThreatment(this.PROPOFID_NSAS_SIVPF)} , {FieldThreatment(this.PROPOFID_ORIGEM_PROPOSTA)} , CURRENT TIMESTAMP , {FieldThreatment(this.PROPOFID_NSL)} , {FieldThreatment(this.PROPOFID_NSAC_SIVPF)} , {FieldThreatment(this.PROPOFID_SITUACAO_ENVIO)} , {FieldThreatment(this.PROPOFID_OPCAO_COBER)} , {FieldThreatment(this.PROPOFID_COD_PLANO)} ,  {FieldThreatment((this.VIND_NULL?.ToInt() == -1 ? null : this.PROPOFID_NOME_CONJUGE))},  {FieldThreatment((this.VIND_NULL?.ToInt() == -1 ? null : this.PROPOFID_DATA_NASC_CONJUGE))},  {FieldThreatment((this.VIND_NULL?.ToInt() == -1 ? null : this.PROPOFID_PROFISSAO_CONJUGE))},  {FieldThreatment((this.VIND_NULL?.ToInt() == -1 ? null : this.PROPOFID_FAIXA_RENDA_IND))},  {FieldThreatment((this.VIND_NULL?.ToInt() == -1 ? null : this.PROPOFID_FAIXA_RENDA_FAM))}, {FieldThreatment(this.PROPOFID_IND_TIPO_CONTA)} )";

            return query;
        }
        public string PROPOFID_NUM_PROPOSTA_SIVPF { get; set; }
        public string PROPOFID_NUM_IDENTIFICACAO { get; set; }
        public string PROPOFID_COD_EMPRESA_SIVPF { get; set; }
        public string PESSOA_COD_PESSOA { get; set; }
        public string PROPOFID_NUM_SICOB { get; set; }
        public string PROPOFID_DATA_PROPOSTA { get; set; }
        public string PROPOFID_COD_PRODUTO_SIVPF { get; set; }
        public string PROPOFID_AGECOBR { get; set; }
        public string PROPOFID_DIA_DEBITO { get; set; }
        public string PROPOFID_OPCAOPAG { get; set; }
        public string PROPOFID_AGECTADEB { get; set; }
        public string PROPOFID_OPRCTADEB { get; set; }
        public string PROPOFID_NUMCTADEB { get; set; }
        public string PROPOFID_DIGCTADEB { get; set; }
        public string PROPOFID_PERC_DESCONTO { get; set; }
        public string PROPOFID_NRMATRVEN { get; set; }
        public string PROPOFID_AGECTAVEN { get; set; }
        public string PROPOFID_OPRCTAVEN { get; set; }
        public string PROPOFID_NUMCTAVEN { get; set; }
        public string PROPOFID_DIGCTAVEN { get; set; }
        public string PROPOFID_CGC_CONVENENTE { get; set; }
        public string PROPOFID_NOME_CONVENENTE { get; set; }
        public string PROPOFID_NRMATRCON { get; set; }
        public string PROPOFID_DTQITBCO { get; set; }
        public string PROPOFID_VAL_PAGO { get; set; }
        public string PROPOFID_AGEPGTO { get; set; }
        public string PROPOFID_VAL_TARIFA { get; set; }
        public string PROPOFID_VAL_IOF { get; set; }
        public string PROPOFID_DATA_CREDITO { get; set; }
        public string PROPOFID_VAL_COMISSAO { get; set; }
        public string PROPOFID_SIT_PROPOSTA { get; set; }
        public string PROPOFID_COD_USUARIO { get; set; }
        public string PROPOFID_CANAL_PROPOSTA { get; set; }
        public string PROPOFID_NSAS_SIVPF { get; set; }
        public string PROPOFID_ORIGEM_PROPOSTA { get; set; }
        public string PROPOFID_NSL { get; set; }
        public string PROPOFID_NSAC_SIVPF { get; set; }
        public string PROPOFID_SITUACAO_ENVIO { get; set; }
        public string PROPOFID_OPCAO_COBER { get; set; }
        public string PROPOFID_COD_PLANO { get; set; }
        public string PROPOFID_NOME_CONJUGE { get; set; }
        public string VIND_NULL { get; set; }
        public string PROPOFID_DATA_NASC_CONJUGE { get; set; }
        public string PROPOFID_PROFISSAO_CONJUGE { get; set; }
        public string PROPOFID_FAIXA_RENDA_IND { get; set; }
        public string PROPOFID_FAIXA_RENDA_FAM { get; set; }
        public string PROPOFID_IND_TIPO_CONTA { get; set; }

        public static void Execute(R1920_00_INSERT_PROPOFID_DB_INSERT_1_Insert1 r1920_00_INSERT_PROPOFID_DB_INSERT_1_Insert1)
        {
            var ths = r1920_00_INSERT_PROPOFID_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1920_00_INSERT_PROPOFID_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}