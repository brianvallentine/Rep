using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0600B
{
    public class R0860_TRATA_INC_CARTAO_DB_INSERT_1_Insert1 : QueryBasis<R0860_TRATA_INC_CARTAO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT
            INTO SEGUROS.PROPOSTAS_VA
            VALUES (:DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF ,
            :DCLPRODUTOS-VG.PRODUVG-COD-PRODUTO ,
            9999 ,
            :DCLPESSOA-ENDERECO.OCORR-ENDERECO ,
            :WHOST-FONTE ,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-AGECOBR ,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-OPCAO-COBER ,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO ,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-AGECTAVEN ,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-OPRCTAVEN ,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-NUMCTAVEN ,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-DIGCTAVEN ,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-NRMATRVEN ,
            106 ,
            ' ' ,
            :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO ,
            :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO ,
            :WHOST-SIT-REGISTRO ,
            :DCLPROP-SASSE-VIDA.PROPSSVD-NUM-APOLICE ,
            :DCLPROP-SASSE-VIDA.PROPSSVD-COD-SUBGRUPO ,
            1 ,
            0 ,
            0 ,
            :WHOST-DTPROXVEN ,
            1 ,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO ,
            '0' ,
            :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO,
            'PF0600B' ,
            CURRENT TIMESTAMP,
            0,
            :DCLPESSOA-FISICA.SEXO,
            :DCLPESSOA-FISICA.ESTADO-CIVIL,
            NULL,
            NULL,
            NULL,
            :DCLPROP-SASSE-VIDA.PROPSSVD-APOS-INVALIDEZ ,
            ' ' ,
            ' ' ,
            NULL,
            NULL,
            NULL,
            :DCLPROP-SASSE-VIDA.PROPSSVD-DPS-TITULAR ,
            :DCLPROP-SASSE-VIDA.PROPSSVD-DPS-CONJUGE ,
            NULL,
            NULL,
            NULL,
            NULL,
            NULL,
            NULL,
            NULL,
            NULL,
            NULL,
            NULL,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-FAIXA-RENDA-IND,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-FAIXA-RENDA-IND,
            :PROPSSVD-NUM-CONTR-VINCULO:VIND-OPER-CREDITO,
            :PROPSSVD-COD-CORRESP-BANC :VIND-OPER-CREDITO,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-ORIGEM-PROPOSTA
            :VIND-ZEROS,
            :PROPSSVD-NUM-PRAZO-FIN :VIND-NUM-PRAZO,
            :PROPSSVD-COD-OPER-CREDITO:VIND-OPER-CREDITO ,
            ' ' ,
            ' ' ,
            NULL)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.PROPOSTAS_VA VALUES ({FieldThreatment(this.PROPOFID_NUM_PROPOSTA_SIVPF)} , {FieldThreatment(this.PRODUVG_COD_PRODUTO)} , 9999 , {FieldThreatment(this.OCORR_ENDERECO)} , {FieldThreatment(this.WHOST_FONTE)} , {FieldThreatment(this.PROPOFID_AGECOBR)} , {FieldThreatment(this.PROPOFID_OPCAO_COBER)} , {FieldThreatment(this.PROPOFID_DTQITBCO)} , {FieldThreatment(this.PROPOFID_AGECTAVEN)} , {FieldThreatment(this.PROPOFID_OPRCTAVEN)} , {FieldThreatment(this.PROPOFID_NUMCTAVEN)} , {FieldThreatment(this.PROPOFID_DIGCTAVEN)} , {FieldThreatment(this.PROPOFID_NRMATRVEN)} , 106 , ' ' , {FieldThreatment(this.SISTEMAS_DATA_MOV_ABERTO)} , {FieldThreatment(this.SISTEMAS_DATA_MOV_ABERTO)} , {FieldThreatment(this.WHOST_SIT_REGISTRO)} , {FieldThreatment(this.PROPSSVD_NUM_APOLICE)} , {FieldThreatment(this.PROPSSVD_COD_SUBGRUPO)} , 1 , 0 , 0 , {FieldThreatment(this.WHOST_DTPROXVEN)} , 1 , {FieldThreatment(this.PROPOFID_DTQITBCO)} , '0' , {FieldThreatment(this.SISTEMAS_DATA_MOV_ABERTO)}, 'PF0600B' , CURRENT TIMESTAMP, 0, {FieldThreatment(this.SEXO)}, {FieldThreatment(this.ESTADO_CIVIL)}, NULL, NULL, NULL, {FieldThreatment(this.PROPSSVD_APOS_INVALIDEZ)} , ' ' , ' ' , NULL, NULL, NULL, {FieldThreatment(this.PROPSSVD_DPS_TITULAR)} , {FieldThreatment(this.PROPSSVD_DPS_CONJUGE)} , NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, {FieldThreatment(this.PROPOFID_FAIXA_RENDA_IND)}, {FieldThreatment(this.PROPOFID_FAIXA_RENDA_IND)},  {FieldThreatment((this.VIND_OPER_CREDITO?.ToInt() == -1 ? null : this.PROPSSVD_NUM_CONTR_VINCULO))},  {FieldThreatment((this.VIND_OPER_CREDITO?.ToInt() == -1 ? null : this.PROPSSVD_COD_CORRESP_BANC))},  {FieldThreatment((this.VIND_ZEROS?.ToInt() == -1 ? null : this.PROPOFID_ORIGEM_PROPOSTA))},  {FieldThreatment((this.VIND_NUM_PRAZO?.ToInt() == -1 ? null : this.PROPSSVD_NUM_PRAZO_FIN))},  {FieldThreatment((this.VIND_OPER_CREDITO?.ToInt() == -1 ? null : this.PROPSSVD_COD_OPER_CREDITO))} , ' ' , ' ' , NULL)";

            return query;
        }
        public string PROPOFID_NUM_PROPOSTA_SIVPF { get; set; }
        public string PRODUVG_COD_PRODUTO { get; set; }
        public string OCORR_ENDERECO { get; set; }
        public string WHOST_FONTE { get; set; }
        public string PROPOFID_AGECOBR { get; set; }
        public string PROPOFID_OPCAO_COBER { get; set; }
        public string PROPOFID_DTQITBCO { get; set; }
        public string PROPOFID_AGECTAVEN { get; set; }
        public string PROPOFID_OPRCTAVEN { get; set; }
        public string PROPOFID_NUMCTAVEN { get; set; }
        public string PROPOFID_DIGCTAVEN { get; set; }
        public string PROPOFID_NRMATRVEN { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string WHOST_SIT_REGISTRO { get; set; }
        public string PROPSSVD_NUM_APOLICE { get; set; }
        public string PROPSSVD_COD_SUBGRUPO { get; set; }
        public string WHOST_DTPROXVEN { get; set; }
        public string SEXO { get; set; }
        public string ESTADO_CIVIL { get; set; }
        public string PROPSSVD_APOS_INVALIDEZ { get; set; }
        public string PROPSSVD_DPS_TITULAR { get; set; }
        public string PROPSSVD_DPS_CONJUGE { get; set; }
        public string PROPOFID_FAIXA_RENDA_IND { get; set; }
        public string PROPSSVD_NUM_CONTR_VINCULO { get; set; }
        public string VIND_OPER_CREDITO { get; set; }
        public string PROPSSVD_COD_CORRESP_BANC { get; set; }
        public string PROPOFID_ORIGEM_PROPOSTA { get; set; }
        public string VIND_ZEROS { get; set; }
        public string PROPSSVD_NUM_PRAZO_FIN { get; set; }
        public string VIND_NUM_PRAZO { get; set; }
        public string PROPSSVD_COD_OPER_CREDITO { get; set; }

        public static void Execute(R0860_TRATA_INC_CARTAO_DB_INSERT_1_Insert1 r0860_TRATA_INC_CARTAO_DB_INSERT_1_Insert1)
        {
            var ths = r0860_TRATA_INC_CARTAO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0860_TRATA_INC_CARTAO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}