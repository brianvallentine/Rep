using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0601B
{
    public class R1110_00_INSERT_PROPOSTA_VA_DB_INSERT_1_Insert1 : QueryBasis<R1110_00_INSERT_PROPOSTA_VA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT
            INTO SEGUROS.PROPOSTAS_VA
            ( NUM_CERTIFICADO ,
            COD_PRODUTO ,
            COD_CLIENTE ,
            OCOREND ,
            COD_FONTE ,
            AGE_COBRANCA ,
            OPCAO_COBERTURA ,
            DATA_QUITACAO ,
            COD_AGE_VENDEDOR ,
            OPE_CONTA_VENDEDOR ,
            NUM_CONTA_VENDEDOR ,
            DIG_CONTA_VENDEDOR ,
            NUM_MATRI_VENDEDOR ,
            COD_OPERACAO ,
            PROFISSAO ,
            DTINCLUS ,
            DATA_MOVIMENTO ,
            SIT_REGISTRO ,
            NUM_APOLICE ,
            COD_SUBGRUPO ,
            OCORR_HISTORICO ,
            NRPRIPARATZ ,
            QTDPARATZ ,
            DTPROXVEN ,
            NUM_PARCELA ,
            DATA_VENCIMENTO ,
            SIT_INTERFACE ,
            DTFENAE ,
            COD_USUARIO ,
            TIMESTAMP ,
            IDADE ,
            IDE_SEXO ,
            ESTADO_CIVIL ,
            OPCAO_MARCADA ,
            SIGLA_CRM ,
            COD_CRM ,
            APOS_INVALIDEZ ,
            ASSINATURA ,
            ACATAMENTO ,
            NOME_ESPOSA ,
            DTNASC_ESPOSA ,
            PROFIS_ESPOSA ,
            DPS_TITULAR ,
            DPS_ESPOSA ,
            NUM_MATRICULA ,
            GRAU_PARENTESCO ,
            DATA_ADMISSAO ,
            NUM_PROPOSTA ,
            EM_ATIVIDADE ,
            LOC_ATIVIDADE ,
            INFO_COMPLEMENTAR ,
            NRMALADIR ,
            NRCERTIFANT ,
            COD_CCT ,
            FAIXA_RENDA_IND ,
            FAIXA_RENDA_FAM ,
            NUM_CONTR_VINCULO ,
            COD_CORRESP_BANC ,
            COD_ORIGEM_PROPOSTA ,
            NUM_PRAZO_FIN ,
            COD_OPER_CREDITO )
            VALUES (:DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF ,
            :DCLPRODUTOS-VG.PRODUVG-COD-PRODUTO ,
            :DCLCLIENTES.COD-CLIENTE ,
            :DCLENDERECOS.ENDERECO-OCORR-ENDERECO ,
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
            :WHOST-PROFISSAO ,
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
            'VP0601B' ,
            CURRENT TIMESTAMP,
            :WHOST-IDADE,
            :DCLPESSOA-FISICA.SEXO,
            :DCLPESSOA-FISICA.ESTADO-CIVIL,
            NULL,
            NULL,
            NULL,
            :DCLPROP-SASSE-VIDA.PROPSSVD-APOS-INVALIDEZ ,
            ' ' ,
            ' ' ,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-NOME-CONJUGE
            :VIND-NOME-CONJUGE,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-DATA-NASC-CONJUGE
            :VIND-DATA-NASC-CONJUGE,
            :WHOST-PROFISSAO-CONJUGE
            :VIND-PROFISSAO-CONJUGE,
            :DCLPROP-SASSE-VIDA.PROPSSVD-DPS-TITULAR ,
            :DCLPROP-SASSE-VIDA.PROPSSVD-DPS-CONJUGE ,
            NULL,
            NULL,
            NULL,
            NULL,
            NULL,
            NULL,
            :WHOST-INFO-COMPL,
            NULL,
            NULL,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-CGC-CONVENENTE
            :VIND-CGC-CONVENENTE,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-FAIXA-RENDA-IND,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-FAIXA-RENDA-FAM,
            :PROPSSVD-NUM-CONTR-VINCULO :VIND-NUM-CONTR ,
            :PROPSSVD-COD-CORRESP-BANC :VIND-COD-CORRESP ,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-ORIGEM-PROPOSTA ,
            :PROPSSVD-NUM-PRAZO-FIN :VIND-NUM-PRAZO ,
            :PROPSSVD-COD-OPER-CREDITO :VIND-COD-OPER-CRED )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.PROPOSTAS_VA ( NUM_CERTIFICADO , COD_PRODUTO , COD_CLIENTE , OCOREND , COD_FONTE , AGE_COBRANCA , OPCAO_COBERTURA , DATA_QUITACAO , COD_AGE_VENDEDOR , OPE_CONTA_VENDEDOR , NUM_CONTA_VENDEDOR , DIG_CONTA_VENDEDOR , NUM_MATRI_VENDEDOR , COD_OPERACAO , PROFISSAO , DTINCLUS , DATA_MOVIMENTO , SIT_REGISTRO , NUM_APOLICE , COD_SUBGRUPO , OCORR_HISTORICO , NRPRIPARATZ , QTDPARATZ , DTPROXVEN , NUM_PARCELA , DATA_VENCIMENTO , SIT_INTERFACE , DTFENAE , COD_USUARIO , TIMESTAMP , IDADE , IDE_SEXO , ESTADO_CIVIL , OPCAO_MARCADA , SIGLA_CRM , COD_CRM , APOS_INVALIDEZ , ASSINATURA , ACATAMENTO , NOME_ESPOSA , DTNASC_ESPOSA , PROFIS_ESPOSA , DPS_TITULAR , DPS_ESPOSA , NUM_MATRICULA , GRAU_PARENTESCO , DATA_ADMISSAO , NUM_PROPOSTA , EM_ATIVIDADE , LOC_ATIVIDADE , INFO_COMPLEMENTAR , NRMALADIR , NRCERTIFANT , COD_CCT , FAIXA_RENDA_IND , FAIXA_RENDA_FAM , NUM_CONTR_VINCULO , COD_CORRESP_BANC , COD_ORIGEM_PROPOSTA , NUM_PRAZO_FIN , COD_OPER_CREDITO ) VALUES ({FieldThreatment(this.PROPOFID_NUM_PROPOSTA_SIVPF)} , {FieldThreatment(this.PRODUVG_COD_PRODUTO)} , {FieldThreatment(this.COD_CLIENTE)} , {FieldThreatment(this.ENDERECO_OCORR_ENDERECO)} , {FieldThreatment(this.WHOST_FONTE)} , {FieldThreatment(this.PROPOFID_AGECOBR)} , {FieldThreatment(this.PROPOFID_OPCAO_COBER)} , {FieldThreatment(this.PROPOFID_DTQITBCO)} , {FieldThreatment(this.PROPOFID_AGECTAVEN)} , {FieldThreatment(this.PROPOFID_OPRCTAVEN)} , {FieldThreatment(this.PROPOFID_NUMCTAVEN)} , {FieldThreatment(this.PROPOFID_DIGCTAVEN)} , {FieldThreatment(this.PROPOFID_NRMATRVEN)} , 106 , {FieldThreatment(this.WHOST_PROFISSAO)} , {FieldThreatment(this.SISTEMAS_DATA_MOV_ABERTO)} , {FieldThreatment(this.SISTEMAS_DATA_MOV_ABERTO)} , {FieldThreatment(this.WHOST_SIT_REGISTRO)} , {FieldThreatment(this.PROPSSVD_NUM_APOLICE)} , {FieldThreatment(this.PROPSSVD_COD_SUBGRUPO)} , 1 , 0 , 0 , {FieldThreatment(this.WHOST_DTPROXVEN)} , 1 , {FieldThreatment(this.PROPOFID_DTQITBCO)} , '0' , {FieldThreatment(this.SISTEMAS_DATA_MOV_ABERTO)}, 'VP0601B' , CURRENT TIMESTAMP, {FieldThreatment(this.WHOST_IDADE)}, {FieldThreatment(this.SEXO)}, {FieldThreatment(this.ESTADO_CIVIL)}, NULL, NULL, NULL, {FieldThreatment(this.PROPSSVD_APOS_INVALIDEZ)} , ' ' , ' ' ,  {FieldThreatment((this.VIND_NOME_CONJUGE?.ToInt() == -1 ? null : this.PROPOFID_NOME_CONJUGE))},  {FieldThreatment((this.VIND_DATA_NASC_CONJUGE?.ToInt() == -1 ? null : this.PROPOFID_DATA_NASC_CONJUGE))},  {FieldThreatment((this.VIND_PROFISSAO_CONJUGE?.ToInt() == -1 ? null : this.WHOST_PROFISSAO_CONJUGE))}, {FieldThreatment(this.PROPSSVD_DPS_TITULAR)} , {FieldThreatment(this.PROPSSVD_DPS_CONJUGE)} , NULL, NULL, NULL, NULL, NULL, NULL, {FieldThreatment(this.WHOST_INFO_COMPL)}, NULL, NULL,  {FieldThreatment((this.VIND_CGC_CONVENENTE?.ToInt() == -1 ? null : this.PROPOFID_CGC_CONVENENTE))}, {FieldThreatment(this.PROPOFID_FAIXA_RENDA_IND)}, {FieldThreatment(this.PROPOFID_FAIXA_RENDA_FAM)},  {FieldThreatment((this.VIND_NUM_CONTR?.ToInt() == -1 ? null : this.PROPSSVD_NUM_CONTR_VINCULO))} ,  {FieldThreatment((this.VIND_COD_CORRESP?.ToInt() == -1 ? null : this.PROPSSVD_COD_CORRESP_BANC))} , {FieldThreatment(this.PROPOFID_ORIGEM_PROPOSTA)} ,  {FieldThreatment((this.VIND_NUM_PRAZO?.ToInt() == -1 ? null : this.PROPSSVD_NUM_PRAZO_FIN))} ,  {FieldThreatment((this.VIND_COD_OPER_CRED?.ToInt() == -1 ? null : this.PROPSSVD_COD_OPER_CREDITO))} )";

            return query;
        }
        public string PROPOFID_NUM_PROPOSTA_SIVPF { get; set; }
        public string PRODUVG_COD_PRODUTO { get; set; }
        public string COD_CLIENTE { get; set; }
        public string ENDERECO_OCORR_ENDERECO { get; set; }
        public string WHOST_FONTE { get; set; }
        public string PROPOFID_AGECOBR { get; set; }
        public string PROPOFID_OPCAO_COBER { get; set; }
        public string PROPOFID_DTQITBCO { get; set; }
        public string PROPOFID_AGECTAVEN { get; set; }
        public string PROPOFID_OPRCTAVEN { get; set; }
        public string PROPOFID_NUMCTAVEN { get; set; }
        public string PROPOFID_DIGCTAVEN { get; set; }
        public string PROPOFID_NRMATRVEN { get; set; }
        public string WHOST_PROFISSAO { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string WHOST_SIT_REGISTRO { get; set; }
        public string PROPSSVD_NUM_APOLICE { get; set; }
        public string PROPSSVD_COD_SUBGRUPO { get; set; }
        public string WHOST_DTPROXVEN { get; set; }
        public string WHOST_IDADE { get; set; }
        public string SEXO { get; set; }
        public string ESTADO_CIVIL { get; set; }
        public string PROPSSVD_APOS_INVALIDEZ { get; set; }
        public string PROPOFID_NOME_CONJUGE { get; set; }
        public string VIND_NOME_CONJUGE { get; set; }
        public string PROPOFID_DATA_NASC_CONJUGE { get; set; }
        public string VIND_DATA_NASC_CONJUGE { get; set; }
        public string WHOST_PROFISSAO_CONJUGE { get; set; }
        public string VIND_PROFISSAO_CONJUGE { get; set; }
        public string PROPSSVD_DPS_TITULAR { get; set; }
        public string PROPSSVD_DPS_CONJUGE { get; set; }
        public string WHOST_INFO_COMPL { get; set; }
        public string PROPOFID_CGC_CONVENENTE { get; set; }
        public string VIND_CGC_CONVENENTE { get; set; }
        public string PROPOFID_FAIXA_RENDA_IND { get; set; }
        public string PROPOFID_FAIXA_RENDA_FAM { get; set; }
        public string PROPSSVD_NUM_CONTR_VINCULO { get; set; }
        public string VIND_NUM_CONTR { get; set; }
        public string PROPSSVD_COD_CORRESP_BANC { get; set; }
        public string VIND_COD_CORRESP { get; set; }
        public string PROPOFID_ORIGEM_PROPOSTA { get; set; }
        public string PROPSSVD_NUM_PRAZO_FIN { get; set; }
        public string VIND_NUM_PRAZO { get; set; }
        public string PROPSSVD_COD_OPER_CREDITO { get; set; }
        public string VIND_COD_OPER_CRED { get; set; }

        public static void Execute(R1110_00_INSERT_PROPOSTA_VA_DB_INSERT_1_Insert1 r1110_00_INSERT_PROPOSTA_VA_DB_INSERT_1_Insert1)
        {
            var ths = r1110_00_INSERT_PROPOSTA_VA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1110_00_INSERT_PROPOSTA_VA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}