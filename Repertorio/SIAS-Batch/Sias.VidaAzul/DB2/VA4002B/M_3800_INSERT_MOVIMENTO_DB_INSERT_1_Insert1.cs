using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA4002B
{
    public class M_3800_INSERT_MOVIMENTO_DB_INSERT_1_Insert1 : QueryBasis<M_3800_INSERT_MOVIMENTO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0MOVIMENTO
            ( NUM_APOLICE ,
            COD_SUBGRUPO ,
            COD_FONTE ,
            NUM_PROPOSTA ,
            TIPO_SEGURADO ,
            NUM_CERTIFICADO ,
            DAC_CERTIFICADO ,
            TIPO_INCLUSAO ,
            COD_CLIENTE ,
            COD_AGENCIADOR ,
            COD_CORRETOR ,
            COD_PLANOVGAP ,
            COD_PLANOAP ,
            FAIXA ,
            AUTOR_AUM_AUTOMAT ,
            TIPO_BENEFICIARIO ,
            PERI_PAGAMENTO ,
            PERI_RENOVACAO ,
            COD_OCUPACAO ,
            ESTADO_CIVIL ,
            IDE_SEXO ,
            COD_PROFISSAO ,
            NATURALIDADE ,
            OCORR_ENDERECO ,
            OCORR_END_COBRAN ,
            BCO_COBRANCA ,
            AGE_COBRANCA ,
            DAC_COBRANCA ,
            NUM_MATRICULA ,
            NUM_CTA_CORRENTE ,
            DAC_CTA_CORRENTE ,
            VAL_SALARIO ,
            TIPO_SALARIO ,
            TIPO_PLANO ,
            PCT_CONJUGE_VG ,
            PCT_CONJUGE_AP ,
            QTD_SAL_MORNATU ,
            QTD_SAL_MORACID ,
            QTD_SAL_INVPERM ,
            TAXA_AP_MORACID ,
            TAXA_AP_INVPERM ,
            TAXA_AP_AMDS ,
            TAXA_AP_DH ,
            TAXA_AP_DIT ,
            TAXA_VG ,
            IMP_MORNATU_ANT ,
            IMP_MORNATU_ATU ,
            IMP_MORACID_ANT ,
            IMP_MORACID_ATU ,
            IMP_INVPERM_ANT ,
            IMP_INVPERM_ATU ,
            IMP_AMDS_ANT ,
            IMP_AMDS_ATU ,
            IMP_DH_ANT ,
            IMP_DH_ATU ,
            IMP_DIT_ANT ,
            IMP_DIT_ATU ,
            PRM_VG_ANT ,
            PRM_VG_ATU ,
            PRM_AP_ANT ,
            PRM_AP_ATU ,
            COD_OPERACAO ,
            DATA_OPERACAO ,
            COD_SUBGRUPO_TRANS ,
            SIT_REGISTRO ,
            COD_USUARIO ,
            DATA_AVERBACAO ,
            DATA_ADMISSAO ,
            DATA_INCLUSAO ,
            DATA_NASCIMENTO ,
            DATA_FATURA ,
            DATA_REFERENCIA ,
            DATA_MOVIMENTO ,
            COD_EMPRESA ,
            LOT_EMP_SEGURADO)
            VALUES (:PROPVA-NUM-APOLICE,
            :PROPVA-CODSUBES,
            :PROPVA-FONTE,
            :FONTE-PROPAUTOM,
            '1' ,
            :PROPVA-NRCERTIF,
            ' ' ,
            '4' ,
            :PROPVA-CODCLIEN,
            0,
            0,
            0,
            0,
            0,
            'S' ,
            'N' ,
            :OPCAOP-PERIPGTO,
            12,
            ' ' ,
            :PROPVA-EST-CIV,
            :PROPVA-SEXO,
            0,
            ' ' ,
            1,
            1,
            104,
            :CONTACOR-COD-AGENCIA,
            ' ' ,
            0,
            :CONTACOR-NUM-CTA-CORRENTE,
            :CONTACOR-DAC-CTA-CORRENTE,
            0,
            ' ' ,
            '1' ,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            :HISCOBPR-IMP_MORNATU,
            0,
            :HISCOBPR-IMPMORACID,
            0,
            :HISCOBPR-IMPINVPERM,
            0,
            0,
            0,
            0,
            :HISCOBPR-IMPDIT,
            :HISCOBPR-IMPDIT,
            :HISCOBPR-PRMVG,
            :HISCOBPR-PRMVG,
            :HISCOBPR-PRMAP,
            :HISCOBPR-PRMAP,
            101,
            CURRENT DATE,
            0,
            '1' ,
            'VA4002B' ,
            CURRENT DATE,
            :PROPVA-DTADMIS:PROPVA-IDTADMIS,
            :PROPVA-DTINCLUS,
            :CLIENT-DTNASC,
            NULL,
            :FATURCON-DATA-REFERENCIA:VIND-DATA-REF,
            :PROPVA-DTQITBCO,
            NULL,
            NULL)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0MOVIMENTO ( NUM_APOLICE , COD_SUBGRUPO , COD_FONTE , NUM_PROPOSTA , TIPO_SEGURADO , NUM_CERTIFICADO , DAC_CERTIFICADO , TIPO_INCLUSAO , COD_CLIENTE , COD_AGENCIADOR , COD_CORRETOR , COD_PLANOVGAP , COD_PLANOAP , FAIXA , AUTOR_AUM_AUTOMAT , TIPO_BENEFICIARIO , PERI_PAGAMENTO , PERI_RENOVACAO , COD_OCUPACAO , ESTADO_CIVIL , IDE_SEXO , COD_PROFISSAO , NATURALIDADE , OCORR_ENDERECO , OCORR_END_COBRAN , BCO_COBRANCA , AGE_COBRANCA , DAC_COBRANCA , NUM_MATRICULA , NUM_CTA_CORRENTE , DAC_CTA_CORRENTE , VAL_SALARIO , TIPO_SALARIO , TIPO_PLANO , PCT_CONJUGE_VG , PCT_CONJUGE_AP , QTD_SAL_MORNATU , QTD_SAL_MORACID , QTD_SAL_INVPERM , TAXA_AP_MORACID , TAXA_AP_INVPERM , TAXA_AP_AMDS , TAXA_AP_DH , TAXA_AP_DIT , TAXA_VG , IMP_MORNATU_ANT , IMP_MORNATU_ATU , IMP_MORACID_ANT , IMP_MORACID_ATU , IMP_INVPERM_ANT , IMP_INVPERM_ATU , IMP_AMDS_ANT , IMP_AMDS_ATU , IMP_DH_ANT , IMP_DH_ATU , IMP_DIT_ANT , IMP_DIT_ATU , PRM_VG_ANT , PRM_VG_ATU , PRM_AP_ANT , PRM_AP_ATU , COD_OPERACAO , DATA_OPERACAO , COD_SUBGRUPO_TRANS , SIT_REGISTRO , COD_USUARIO , DATA_AVERBACAO , DATA_ADMISSAO , DATA_INCLUSAO , DATA_NASCIMENTO , DATA_FATURA , DATA_REFERENCIA , DATA_MOVIMENTO , COD_EMPRESA , LOT_EMP_SEGURADO) VALUES ({FieldThreatment(this.PROPVA_NUM_APOLICE)}, {FieldThreatment(this.PROPVA_CODSUBES)}, {FieldThreatment(this.PROPVA_FONTE)}, {FieldThreatment(this.FONTE_PROPAUTOM)}, '1' , {FieldThreatment(this.PROPVA_NRCERTIF)}, ' ' , '4' , {FieldThreatment(this.PROPVA_CODCLIEN)}, 0, 0, 0, 0, 0, 'S' , 'N' , {FieldThreatment(this.OPCAOP_PERIPGTO)}, 12, ' ' , {FieldThreatment(this.PROPVA_EST_CIV)}, {FieldThreatment(this.PROPVA_SEXO)}, 0, ' ' , 1, 1, 104, {FieldThreatment(this.CONTACOR_COD_AGENCIA)}, ' ' , 0, {FieldThreatment(this.CONTACOR_NUM_CTA_CORRENTE)}, {FieldThreatment(this.CONTACOR_DAC_CTA_CORRENTE)}, 0, ' ' , '1' , 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, {FieldThreatment(this.HISCOBPR_IMP_MORNATU)}, 0, {FieldThreatment(this.HISCOBPR_IMPMORACID)}, 0, {FieldThreatment(this.HISCOBPR_IMPINVPERM)}, 0, 0, 0, 0, {FieldThreatment(this.HISCOBPR_IMPDIT)}, {FieldThreatment(this.HISCOBPR_IMPDIT)}, {FieldThreatment(this.HISCOBPR_PRMVG)}, {FieldThreatment(this.HISCOBPR_PRMVG)}, {FieldThreatment(this.HISCOBPR_PRMAP)}, {FieldThreatment(this.HISCOBPR_PRMAP)}, 101, CURRENT DATE, 0, '1' , 'VA4002B' , CURRENT DATE,  {FieldThreatment((this.PROPVA_IDTADMIS?.ToInt() == -1 ? null : this.PROPVA_DTADMIS))}, {FieldThreatment(this.PROPVA_DTINCLUS)}, {FieldThreatment(this.CLIENT_DTNASC)}, NULL,  {FieldThreatment((this.VIND_DATA_REF?.ToInt() == -1 ? null : this.FATURCON_DATA_REFERENCIA))}, {FieldThreatment(this.PROPVA_DTQITBCO)}, NULL, NULL)";

            return query;
        }
        public string PROPVA_NUM_APOLICE { get; set; }
        public string PROPVA_CODSUBES { get; set; }
        public string PROPVA_FONTE { get; set; }
        public string FONTE_PROPAUTOM { get; set; }
        public string PROPVA_NRCERTIF { get; set; }
        public string PROPVA_CODCLIEN { get; set; }
        public string OPCAOP_PERIPGTO { get; set; }
        public string PROPVA_EST_CIV { get; set; }
        public string PROPVA_SEXO { get; set; }
        public string CONTACOR_COD_AGENCIA { get; set; }
        public string CONTACOR_NUM_CTA_CORRENTE { get; set; }
        public string CONTACOR_DAC_CTA_CORRENTE { get; set; }
        public string HISCOBPR_IMP_MORNATU { get; set; }
        public string HISCOBPR_IMPMORACID { get; set; }
        public string HISCOBPR_IMPINVPERM { get; set; }
        public string HISCOBPR_IMPDIT { get; set; }
        public string HISCOBPR_PRMVG { get; set; }
        public string HISCOBPR_PRMAP { get; set; }
        public string PROPVA_DTADMIS { get; set; }
        public string PROPVA_IDTADMIS { get; set; }
        public string PROPVA_DTINCLUS { get; set; }
        public string CLIENT_DTNASC { get; set; }
        public string FATURCON_DATA_REFERENCIA { get; set; }
        public string VIND_DATA_REF { get; set; }
        public string PROPVA_DTQITBCO { get; set; }

        public static void Execute(M_3800_INSERT_MOVIMENTO_DB_INSERT_1_Insert1 m_3800_INSERT_MOVIMENTO_DB_INSERT_1_Insert1)
        {
            var ths = m_3800_INSERT_MOVIMENTO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_3800_INSERT_MOVIMENTO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}