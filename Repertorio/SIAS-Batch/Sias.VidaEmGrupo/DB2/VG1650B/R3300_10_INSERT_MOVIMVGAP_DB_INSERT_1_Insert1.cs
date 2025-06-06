using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1650B
{
    public class R3300_10_INSERT_MOVIMVGAP_DB_INSERT_1_Insert1 : QueryBasis<R3300_10_INSERT_MOVIMVGAP_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO
            SEGUROS.MOVIMENTO_VGAP
            ( NUM_APOLICE,
            COD_SUBGRUPO,
            COD_FONTE,
            NUM_PROPOSTA,
            TIPO_SEGURADO,
            NUM_CERTIFICADO,
            DAC_CERTIFICADO,
            TIPO_INCLUSAO,
            COD_CLIENTE,
            COD_AGENCIADOR,
            COD_CORRETOR,
            COD_PLANOVGAP,
            COD_PLANOAP,
            FAIXA,
            AUTOR_AUM_AUTOMAT,
            TIPO_BENEFICIARIO,
            PERI_PAGAMENTO,
            PERI_RENOVACAO,
            COD_OCUPACAO,
            ESTADO_CIVIL,
            IDE_SEXO,
            COD_PROFISSAO,
            NATURALIDADE,
            OCORR_ENDERECO,
            OCORR_END_COBRAN,
            BCO_COBRANCA,
            AGE_COBRANCA,
            DAC_COBRANCA,
            NUM_MATRICULA,
            NUM_CTA_CORRENTE,
            DAC_CTA_CORRENTE,
            VAL_SALARIO,
            TIPO_SALARIO,
            TIPO_PLANO,
            PCT_CONJUGE_VG,
            PCT_CONJUGE_AP,
            QTD_SAL_MORNATU,
            QTD_SAL_MORACID,
            QTD_SAL_INVPERM,
            TAXA_AP_MORACID,
            TAXA_AP_INVPERM,
            TAXA_AP_AMDS,
            TAXA_AP_DH,
            TAXA_AP_DIT,
            TAXA_VG,
            IMP_MORNATU_ANT,
            IMP_MORNATU_ATU,
            IMP_MORACID_ANT,
            IMP_MORACID_ATU,
            IMP_INVPERM_ANT,
            IMP_INVPERM_ATU,
            IMP_AMDS_ANT,
            IMP_AMDS_ATU,
            IMP_DH_ANT,
            IMP_DH_ATU,
            IMP_DIT_ANT,
            IMP_DIT_ATU,
            PRM_VG_ANT,
            PRM_VG_ATU,
            PRM_AP_ANT,
            PRM_AP_ATU,
            COD_OPERACAO,
            DATA_OPERACAO,
            COD_SUBGRUPO_TRANS,
            SIT_REGISTRO,
            COD_USUARIO,
            DATA_AVERBACAO,
            DATA_ADMISSAO,
            DATA_INCLUSAO,
            DATA_NASCIMENTO,
            DATA_FATURA,
            DATA_REFERENCIA,
            DATA_MOVIMENTO,
            COD_EMPRESA,
            LOT_EMP_SEGURADO)
            VALUES
            (:MOVIMVGA-NUM-APOLICE,
            :MOVIMVGA-COD-SUBGRUPO,
            :MOVIMVGA-COD-FONTE,
            :MOVIMVGA-NUM-PROPOSTA,
            :MOVIMVGA-TIPO-SEGURADO,
            :MOVIMVGA-NUM-CERTIFICADO,
            :MOVIMVGA-DAC-CERTIFICADO,
            :MOVIMVGA-TIPO-INCLUSAO,
            :MOVIMVGA-COD-CLIENTE,
            :MOVIMVGA-COD-AGENCIADOR,
            :MOVIMVGA-COD-CORRETOR,
            :MOVIMVGA-COD-PLANOVGAP,
            :MOVIMVGA-COD-PLANOAP,
            :MOVIMVGA-FAIXA,
            :MOVIMVGA-AUTOR-AUM-AUTOMAT,
            :MOVIMVGA-TIPO-BENEFICIARIO,
            :MOVIMVGA-PERI-PAGAMENTO,
            :MOVIMVGA-PERI-RENOVACAO,
            :MOVIMVGA-COD-OCUPACAO,
            :MOVIMVGA-ESTADO-CIVIL,
            :MOVIMVGA-IDE-SEXO,
            :MOVIMVGA-COD-PROFISSAO,
            :MOVIMVGA-NATURALIDADE,
            :MOVIMVGA-OCORR-ENDERECO,
            :MOVIMVGA-OCORR-END-COBRAN,
            :MOVIMVGA-BCO-COBRANCA,
            :MOVIMVGA-AGE-COBRANCA,
            :MOVIMVGA-DAC-COBRANCA,
            :MOVIMVGA-NUM-MATRICULA,
            :MOVIMVGA-NUM-CTA-CORRENTE,
            :MOVIMVGA-DAC-CTA-CORRENTE,
            :MOVIMVGA-VAL-SALARIO,
            :MOVIMVGA-TIPO-SALARIO,
            :MOVIMVGA-TIPO-PLANO,
            :MOVIMVGA-PCT-CONJUGE-VG,
            :MOVIMVGA-PCT-CONJUGE-AP,
            :MOVIMVGA-QTD-SAL-MORNATU,
            :MOVIMVGA-QTD-SAL-MORACID,
            :MOVIMVGA-QTD-SAL-INVPERM,
            :MOVIMVGA-TAXA-AP-MORACID,
            :MOVIMVGA-TAXA-AP-INVPERM,
            :MOVIMVGA-TAXA-AP-AMDS,
            :MOVIMVGA-TAXA-AP-DH,
            :MOVIMVGA-TAXA-AP-DIT,
            :MOVIMVGA-TAXA-VG,
            :MOVIMVGA-IMP-MORNATU-ANT,
            :MOVIMVGA-IMP-MORNATU-ATU,
            :MOVIMVGA-IMP-MORACID-ANT,
            :MOVIMVGA-IMP-MORACID-ATU,
            :MOVIMVGA-IMP-INVPERM-ANT,
            :MOVIMVGA-IMP-INVPERM-ATU,
            :MOVIMVGA-IMP-AMDS-ANT,
            :MOVIMVGA-IMP-AMDS-ATU,
            :MOVIMVGA-IMP-DH-ANT,
            :MOVIMVGA-IMP-DH-ATU,
            :MOVIMVGA-IMP-DIT-ANT,
            :MOVIMVGA-IMP-DIT-ATU,
            :MOVIMVGA-PRM-VG-ANT,
            :MOVIMVGA-PRM-VG-ATU,
            :MOVIMVGA-PRM-AP-ANT,
            :MOVIMVGA-PRM-AP-ATU,
            :MOVIMVGA-COD-OPERACAO,
            :MOVIMVGA-DATA-OPERACAO,
            :MOVIMVGA-COD-SUBGRUPO-TRANS,
            :MOVIMVGA-SIT-REGISTRO,
            :MOVIMVGA-COD-USUARIO,
            :MOVIMVGA-DATA-AVERBACAO:VIND-DATA-AVERBACAO,
            :MOVIMVGA-DATA-ADMISSAO:VIND-DATA-ADMISSAO,
            :MOVIMVGA-DATA-INCLUSAO:VIND-DATA-INCLUSAO,
            :MOVIMVGA-DATA-NASCIMENTO:VIND-DATA-NASCIMENTO,
            :MOVIMVGA-DATA-FATURA:VIND-DATA-FATURA,
            :MOVIMVGA-DATA-REFERENCIA,
            :MOVIMVGA-DATA-MOVIMENTO,
            :MOVIMVGA-COD-EMPRESA:VIND-COD-EMPRESA,
            :MOVIMVGA-LOT-EMP-SEGURADO:VIND-LOT-EMP-SEGURADO)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.MOVIMENTO_VGAP ( NUM_APOLICE, COD_SUBGRUPO, COD_FONTE, NUM_PROPOSTA, TIPO_SEGURADO, NUM_CERTIFICADO, DAC_CERTIFICADO, TIPO_INCLUSAO, COD_CLIENTE, COD_AGENCIADOR, COD_CORRETOR, COD_PLANOVGAP, COD_PLANOAP, FAIXA, AUTOR_AUM_AUTOMAT, TIPO_BENEFICIARIO, PERI_PAGAMENTO, PERI_RENOVACAO, COD_OCUPACAO, ESTADO_CIVIL, IDE_SEXO, COD_PROFISSAO, NATURALIDADE, OCORR_ENDERECO, OCORR_END_COBRAN, BCO_COBRANCA, AGE_COBRANCA, DAC_COBRANCA, NUM_MATRICULA, NUM_CTA_CORRENTE, DAC_CTA_CORRENTE, VAL_SALARIO, TIPO_SALARIO, TIPO_PLANO, PCT_CONJUGE_VG, PCT_CONJUGE_AP, QTD_SAL_MORNATU, QTD_SAL_MORACID, QTD_SAL_INVPERM, TAXA_AP_MORACID, TAXA_AP_INVPERM, TAXA_AP_AMDS, TAXA_AP_DH, TAXA_AP_DIT, TAXA_VG, IMP_MORNATU_ANT, IMP_MORNATU_ATU, IMP_MORACID_ANT, IMP_MORACID_ATU, IMP_INVPERM_ANT, IMP_INVPERM_ATU, IMP_AMDS_ANT, IMP_AMDS_ATU, IMP_DH_ANT, IMP_DH_ATU, IMP_DIT_ANT, IMP_DIT_ATU, PRM_VG_ANT, PRM_VG_ATU, PRM_AP_ANT, PRM_AP_ATU, COD_OPERACAO, DATA_OPERACAO, COD_SUBGRUPO_TRANS, SIT_REGISTRO, COD_USUARIO, DATA_AVERBACAO, DATA_ADMISSAO, DATA_INCLUSAO, DATA_NASCIMENTO, DATA_FATURA, DATA_REFERENCIA, DATA_MOVIMENTO, COD_EMPRESA, LOT_EMP_SEGURADO) VALUES ({FieldThreatment(this.MOVIMVGA_NUM_APOLICE)}, {FieldThreatment(this.MOVIMVGA_COD_SUBGRUPO)}, {FieldThreatment(this.MOVIMVGA_COD_FONTE)}, {FieldThreatment(this.MOVIMVGA_NUM_PROPOSTA)}, {FieldThreatment(this.MOVIMVGA_TIPO_SEGURADO)}, {FieldThreatment(this.MOVIMVGA_NUM_CERTIFICADO)}, {FieldThreatment(this.MOVIMVGA_DAC_CERTIFICADO)}, {FieldThreatment(this.MOVIMVGA_TIPO_INCLUSAO)}, {FieldThreatment(this.MOVIMVGA_COD_CLIENTE)}, {FieldThreatment(this.MOVIMVGA_COD_AGENCIADOR)}, {FieldThreatment(this.MOVIMVGA_COD_CORRETOR)}, {FieldThreatment(this.MOVIMVGA_COD_PLANOVGAP)}, {FieldThreatment(this.MOVIMVGA_COD_PLANOAP)}, {FieldThreatment(this.MOVIMVGA_FAIXA)}, {FieldThreatment(this.MOVIMVGA_AUTOR_AUM_AUTOMAT)}, {FieldThreatment(this.MOVIMVGA_TIPO_BENEFICIARIO)}, {FieldThreatment(this.MOVIMVGA_PERI_PAGAMENTO)}, {FieldThreatment(this.MOVIMVGA_PERI_RENOVACAO)}, {FieldThreatment(this.MOVIMVGA_COD_OCUPACAO)}, {FieldThreatment(this.MOVIMVGA_ESTADO_CIVIL)}, {FieldThreatment(this.MOVIMVGA_IDE_SEXO)}, {FieldThreatment(this.MOVIMVGA_COD_PROFISSAO)}, {FieldThreatment(this.MOVIMVGA_NATURALIDADE)}, {FieldThreatment(this.MOVIMVGA_OCORR_ENDERECO)}, {FieldThreatment(this.MOVIMVGA_OCORR_END_COBRAN)}, {FieldThreatment(this.MOVIMVGA_BCO_COBRANCA)}, {FieldThreatment(this.MOVIMVGA_AGE_COBRANCA)}, {FieldThreatment(this.MOVIMVGA_DAC_COBRANCA)}, {FieldThreatment(this.MOVIMVGA_NUM_MATRICULA)}, {FieldThreatment(this.MOVIMVGA_NUM_CTA_CORRENTE)}, {FieldThreatment(this.MOVIMVGA_DAC_CTA_CORRENTE)}, {FieldThreatment(this.MOVIMVGA_VAL_SALARIO)}, {FieldThreatment(this.MOVIMVGA_TIPO_SALARIO)}, {FieldThreatment(this.MOVIMVGA_TIPO_PLANO)}, {FieldThreatment(this.MOVIMVGA_PCT_CONJUGE_VG)}, {FieldThreatment(this.MOVIMVGA_PCT_CONJUGE_AP)}, {FieldThreatment(this.MOVIMVGA_QTD_SAL_MORNATU)}, {FieldThreatment(this.MOVIMVGA_QTD_SAL_MORACID)}, {FieldThreatment(this.MOVIMVGA_QTD_SAL_INVPERM)}, {FieldThreatment(this.MOVIMVGA_TAXA_AP_MORACID)}, {FieldThreatment(this.MOVIMVGA_TAXA_AP_INVPERM)}, {FieldThreatment(this.MOVIMVGA_TAXA_AP_AMDS)}, {FieldThreatment(this.MOVIMVGA_TAXA_AP_DH)}, {FieldThreatment(this.MOVIMVGA_TAXA_AP_DIT)}, {FieldThreatment(this.MOVIMVGA_TAXA_VG)}, {FieldThreatment(this.MOVIMVGA_IMP_MORNATU_ANT)}, {FieldThreatment(this.MOVIMVGA_IMP_MORNATU_ATU)}, {FieldThreatment(this.MOVIMVGA_IMP_MORACID_ANT)}, {FieldThreatment(this.MOVIMVGA_IMP_MORACID_ATU)}, {FieldThreatment(this.MOVIMVGA_IMP_INVPERM_ANT)}, {FieldThreatment(this.MOVIMVGA_IMP_INVPERM_ATU)}, {FieldThreatment(this.MOVIMVGA_IMP_AMDS_ANT)}, {FieldThreatment(this.MOVIMVGA_IMP_AMDS_ATU)}, {FieldThreatment(this.MOVIMVGA_IMP_DH_ANT)}, {FieldThreatment(this.MOVIMVGA_IMP_DH_ATU)}, {FieldThreatment(this.MOVIMVGA_IMP_DIT_ANT)}, {FieldThreatment(this.MOVIMVGA_IMP_DIT_ATU)}, {FieldThreatment(this.MOVIMVGA_PRM_VG_ANT)}, {FieldThreatment(this.MOVIMVGA_PRM_VG_ATU)}, {FieldThreatment(this.MOVIMVGA_PRM_AP_ANT)}, {FieldThreatment(this.MOVIMVGA_PRM_AP_ATU)}, {FieldThreatment(this.MOVIMVGA_COD_OPERACAO)}, {FieldThreatment(this.MOVIMVGA_DATA_OPERACAO)}, {FieldThreatment(this.MOVIMVGA_COD_SUBGRUPO_TRANS)}, {FieldThreatment(this.MOVIMVGA_SIT_REGISTRO)}, {FieldThreatment(this.MOVIMVGA_COD_USUARIO)},  {FieldThreatment((this.VIND_DATA_AVERBACAO?.ToInt() == -1 ? null : this.MOVIMVGA_DATA_AVERBACAO))},  {FieldThreatment((this.VIND_DATA_ADMISSAO?.ToInt() == -1 ? null : this.MOVIMVGA_DATA_ADMISSAO))},  {FieldThreatment((this.VIND_DATA_INCLUSAO?.ToInt() == -1 ? null : this.MOVIMVGA_DATA_INCLUSAO))},  {FieldThreatment((this.VIND_DATA_NASCIMENTO?.ToInt() == -1 ? null : this.MOVIMVGA_DATA_NASCIMENTO))},  {FieldThreatment((this.VIND_DATA_FATURA?.ToInt() == -1 ? null : this.MOVIMVGA_DATA_FATURA))}, {FieldThreatment(this.MOVIMVGA_DATA_REFERENCIA)}, {FieldThreatment(this.MOVIMVGA_DATA_MOVIMENTO)},  {FieldThreatment((this.VIND_COD_EMPRESA?.ToInt() == -1 ? null : this.MOVIMVGA_COD_EMPRESA))},  {FieldThreatment((this.VIND_LOT_EMP_SEGURADO?.ToInt() == -1 ? null : this.MOVIMVGA_LOT_EMP_SEGURADO))})";

            return query;
        }
        public string MOVIMVGA_NUM_APOLICE { get; set; }
        public string MOVIMVGA_COD_SUBGRUPO { get; set; }
        public string MOVIMVGA_COD_FONTE { get; set; }
        public string MOVIMVGA_NUM_PROPOSTA { get; set; }
        public string MOVIMVGA_TIPO_SEGURADO { get; set; }
        public string MOVIMVGA_NUM_CERTIFICADO { get; set; }
        public string MOVIMVGA_DAC_CERTIFICADO { get; set; }
        public string MOVIMVGA_TIPO_INCLUSAO { get; set; }
        public string MOVIMVGA_COD_CLIENTE { get; set; }
        public string MOVIMVGA_COD_AGENCIADOR { get; set; }
        public string MOVIMVGA_COD_CORRETOR { get; set; }
        public string MOVIMVGA_COD_PLANOVGAP { get; set; }
        public string MOVIMVGA_COD_PLANOAP { get; set; }
        public string MOVIMVGA_FAIXA { get; set; }
        public string MOVIMVGA_AUTOR_AUM_AUTOMAT { get; set; }
        public string MOVIMVGA_TIPO_BENEFICIARIO { get; set; }
        public string MOVIMVGA_PERI_PAGAMENTO { get; set; }
        public string MOVIMVGA_PERI_RENOVACAO { get; set; }
        public string MOVIMVGA_COD_OCUPACAO { get; set; }
        public string MOVIMVGA_ESTADO_CIVIL { get; set; }
        public string MOVIMVGA_IDE_SEXO { get; set; }
        public string MOVIMVGA_COD_PROFISSAO { get; set; }
        public string MOVIMVGA_NATURALIDADE { get; set; }
        public string MOVIMVGA_OCORR_ENDERECO { get; set; }
        public string MOVIMVGA_OCORR_END_COBRAN { get; set; }
        public string MOVIMVGA_BCO_COBRANCA { get; set; }
        public string MOVIMVGA_AGE_COBRANCA { get; set; }
        public string MOVIMVGA_DAC_COBRANCA { get; set; }
        public string MOVIMVGA_NUM_MATRICULA { get; set; }
        public string MOVIMVGA_NUM_CTA_CORRENTE { get; set; }
        public string MOVIMVGA_DAC_CTA_CORRENTE { get; set; }
        public string MOVIMVGA_VAL_SALARIO { get; set; }
        public string MOVIMVGA_TIPO_SALARIO { get; set; }
        public string MOVIMVGA_TIPO_PLANO { get; set; }
        public string MOVIMVGA_PCT_CONJUGE_VG { get; set; }
        public string MOVIMVGA_PCT_CONJUGE_AP { get; set; }
        public string MOVIMVGA_QTD_SAL_MORNATU { get; set; }
        public string MOVIMVGA_QTD_SAL_MORACID { get; set; }
        public string MOVIMVGA_QTD_SAL_INVPERM { get; set; }
        public string MOVIMVGA_TAXA_AP_MORACID { get; set; }
        public string MOVIMVGA_TAXA_AP_INVPERM { get; set; }
        public string MOVIMVGA_TAXA_AP_AMDS { get; set; }
        public string MOVIMVGA_TAXA_AP_DH { get; set; }
        public string MOVIMVGA_TAXA_AP_DIT { get; set; }
        public string MOVIMVGA_TAXA_VG { get; set; }
        public string MOVIMVGA_IMP_MORNATU_ANT { get; set; }
        public string MOVIMVGA_IMP_MORNATU_ATU { get; set; }
        public string MOVIMVGA_IMP_MORACID_ANT { get; set; }
        public string MOVIMVGA_IMP_MORACID_ATU { get; set; }
        public string MOVIMVGA_IMP_INVPERM_ANT { get; set; }
        public string MOVIMVGA_IMP_INVPERM_ATU { get; set; }
        public string MOVIMVGA_IMP_AMDS_ANT { get; set; }
        public string MOVIMVGA_IMP_AMDS_ATU { get; set; }
        public string MOVIMVGA_IMP_DH_ANT { get; set; }
        public string MOVIMVGA_IMP_DH_ATU { get; set; }
        public string MOVIMVGA_IMP_DIT_ANT { get; set; }
        public string MOVIMVGA_IMP_DIT_ATU { get; set; }
        public string MOVIMVGA_PRM_VG_ANT { get; set; }
        public string MOVIMVGA_PRM_VG_ATU { get; set; }
        public string MOVIMVGA_PRM_AP_ANT { get; set; }
        public string MOVIMVGA_PRM_AP_ATU { get; set; }
        public string MOVIMVGA_COD_OPERACAO { get; set; }
        public string MOVIMVGA_DATA_OPERACAO { get; set; }
        public string MOVIMVGA_COD_SUBGRUPO_TRANS { get; set; }
        public string MOVIMVGA_SIT_REGISTRO { get; set; }
        public string MOVIMVGA_COD_USUARIO { get; set; }
        public string MOVIMVGA_DATA_AVERBACAO { get; set; }
        public string VIND_DATA_AVERBACAO { get; set; }
        public string MOVIMVGA_DATA_ADMISSAO { get; set; }
        public string VIND_DATA_ADMISSAO { get; set; }
        public string MOVIMVGA_DATA_INCLUSAO { get; set; }
        public string VIND_DATA_INCLUSAO { get; set; }
        public string MOVIMVGA_DATA_NASCIMENTO { get; set; }
        public string VIND_DATA_NASCIMENTO { get; set; }
        public string MOVIMVGA_DATA_FATURA { get; set; }
        public string VIND_DATA_FATURA { get; set; }
        public string MOVIMVGA_DATA_REFERENCIA { get; set; }
        public string MOVIMVGA_DATA_MOVIMENTO { get; set; }
        public string MOVIMVGA_COD_EMPRESA { get; set; }
        public string VIND_COD_EMPRESA { get; set; }
        public string MOVIMVGA_LOT_EMP_SEGURADO { get; set; }
        public string VIND_LOT_EMP_SEGURADO { get; set; }

        public static void Execute(R3300_10_INSERT_MOVIMVGAP_DB_INSERT_1_Insert1 r3300_10_INSERT_MOVIMVGAP_DB_INSERT_1_Insert1)
        {
            var ths = r3300_10_INSERT_MOVIMVGAP_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3300_10_INSERT_MOVIMVGAP_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}