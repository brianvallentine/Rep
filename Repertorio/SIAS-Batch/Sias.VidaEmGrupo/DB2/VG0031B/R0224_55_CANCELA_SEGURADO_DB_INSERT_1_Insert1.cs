using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0031B
{
    public class R0224_55_CANCELA_SEGURADO_DB_INSERT_1_Insert1 : QueryBasis<R0224_55_CANCELA_SEGURADO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0MOVIMENTO
            VALUES (:V0SEG-NUM-APOL,
            :V0SEG-COD-SUBG,
            :V0SEG-COD-FONTE,
            :V0FONTE-PROPAUTOM,
            :V0SEG-TP-SEGURADO,
            :V0SEG-NUM-CERTIF,
            :V0SEG-DAC-CERTIF,
            :V0SEG-TP-INCLUSAO,
            :V0SEG-COD-CLIENTE,
            :V0SEG-AGENCIADOR,
            :V0SEG-CORRETOR,
            :V0SEG-CD-PLANOVGAP,
            :V0SEG-CD-PLANOAP,
            :V0SEG-FAIXA,
            :V0SEG-AUT-AUM-AUT,
            :V0SEG-TP-BENEFICIA,
            :V0SEG-PERI-PGTO,
            :V0SEG-PERI-RENOVA,
            :V0SEG-COD-OCUPACAO,
            :V0SEG-EST-CIVIL,
            :V0SEG-SEXO,
            :V0SEG-CD-PROFISSAO,
            :V0SEG-NATURALIDADE,
            :V0SEG-OCOR-ENDERE,
            :V0SEG-OCOR-END-COB,
            :V0SEG-BCO-COBRANCA,
            :V0SEG-AGE-COBRANCA,
            :V0SEG-DAC-COBRANCA,
            :V0SEG-NUM-MATRIC,
            :V0CTAC-NUM-CTA-COR,
            :V0CTAC-DAC-CTA-COR,
            :V0SEG-VAL-SALARIO,
            :V0SEG-TP-SALARIO,
            :V0SEG-TP-PLANO,
            :V0SEG-PCT-CONJ-VG,
            :V0SEG-PCT-CONJ-AP,
            :V0SEG-QTD-S-MONATU,
            :V0SEG-QTD-S-MOACID,
            :V0SEG-QTD-S-INVPER,
            :V0SEG-TX-AP-MOACID,
            :V0SEG-TX-AP-INVPER,
            :V0SEG-TX-AP-AMDS,
            :V0SEG-TX-AP-DH,
            :V0SEG-TX-AP-DIT,
            :V0SEG-TAXA-VG,
            :V0MOV-IMP-MORNATU,
            :V0MOV-IMP-MORNATU,
            :V0MOV-IMP-MORACID,
            :V0MOV-IMP-MORACID,
            :V0MOV-IMP-INVPERM,
            :V0MOV-IMP-INVPERM,
            :V0MOV-IMP-AMDS,
            :V0MOV-IMP-AMDS,
            :V0MOV-IMP-DH,
            :V0MOV-IMP-DH,
            :V0MOV-IMP-DIT,
            :V0MOV-IMP-DIT,
            :V0MOV-PRM-VG,
            :V0MOV-PRM-VG,
            :V0MOV-PRM-AP,
            :V0MOV-PRM-AP,
            409,
            :V1SIST-DTMOVABE,
            0,
            '0' ,
            'VG0031B' ,
            :V1SIST-DTMOVABE,
            :V0SEG-DT-ADMISSAO:VIND-DT-ADMISSAO,
            NULL,
            :V0SEG-DT-NASCI:VIND-DT-NASCI,
            NULL,
            :V1FATC-DT-REFER,
            :V1SIST-DTMOVABE,
            NULL,
            :V0SEG-LOT-EMP-SEGURADO)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0MOVIMENTO VALUES ({FieldThreatment(this.V0SEG_NUM_APOL)}, {FieldThreatment(this.V0SEG_COD_SUBG)}, {FieldThreatment(this.V0SEG_COD_FONTE)}, {FieldThreatment(this.V0FONTE_PROPAUTOM)}, {FieldThreatment(this.V0SEG_TP_SEGURADO)}, {FieldThreatment(this.V0SEG_NUM_CERTIF)}, {FieldThreatment(this.V0SEG_DAC_CERTIF)}, {FieldThreatment(this.V0SEG_TP_INCLUSAO)}, {FieldThreatment(this.V0SEG_COD_CLIENTE)}, {FieldThreatment(this.V0SEG_AGENCIADOR)}, {FieldThreatment(this.V0SEG_CORRETOR)}, {FieldThreatment(this.V0SEG_CD_PLANOVGAP)}, {FieldThreatment(this.V0SEG_CD_PLANOAP)}, {FieldThreatment(this.V0SEG_FAIXA)}, {FieldThreatment(this.V0SEG_AUT_AUM_AUT)}, {FieldThreatment(this.V0SEG_TP_BENEFICIA)}, {FieldThreatment(this.V0SEG_PERI_PGTO)}, {FieldThreatment(this.V0SEG_PERI_RENOVA)}, {FieldThreatment(this.V0SEG_COD_OCUPACAO)}, {FieldThreatment(this.V0SEG_EST_CIVIL)}, {FieldThreatment(this.V0SEG_SEXO)}, {FieldThreatment(this.V0SEG_CD_PROFISSAO)}, {FieldThreatment(this.V0SEG_NATURALIDADE)}, {FieldThreatment(this.V0SEG_OCOR_ENDERE)}, {FieldThreatment(this.V0SEG_OCOR_END_COB)}, {FieldThreatment(this.V0SEG_BCO_COBRANCA)}, {FieldThreatment(this.V0SEG_AGE_COBRANCA)}, {FieldThreatment(this.V0SEG_DAC_COBRANCA)}, {FieldThreatment(this.V0SEG_NUM_MATRIC)}, {FieldThreatment(this.V0CTAC_NUM_CTA_COR)}, {FieldThreatment(this.V0CTAC_DAC_CTA_COR)}, {FieldThreatment(this.V0SEG_VAL_SALARIO)}, {FieldThreatment(this.V0SEG_TP_SALARIO)}, {FieldThreatment(this.V0SEG_TP_PLANO)}, {FieldThreatment(this.V0SEG_PCT_CONJ_VG)}, {FieldThreatment(this.V0SEG_PCT_CONJ_AP)}, {FieldThreatment(this.V0SEG_QTD_S_MONATU)}, {FieldThreatment(this.V0SEG_QTD_S_MOACID)}, {FieldThreatment(this.V0SEG_QTD_S_INVPER)}, {FieldThreatment(this.V0SEG_TX_AP_MOACID)}, {FieldThreatment(this.V0SEG_TX_AP_INVPER)}, {FieldThreatment(this.V0SEG_TX_AP_AMDS)}, {FieldThreatment(this.V0SEG_TX_AP_DH)}, {FieldThreatment(this.V0SEG_TX_AP_DIT)}, {FieldThreatment(this.V0SEG_TAXA_VG)}, {FieldThreatment(this.V0MOV_IMP_MORNATU)}, {FieldThreatment(this.V0MOV_IMP_MORNATU)}, {FieldThreatment(this.V0MOV_IMP_MORACID)}, {FieldThreatment(this.V0MOV_IMP_MORACID)}, {FieldThreatment(this.V0MOV_IMP_INVPERM)}, {FieldThreatment(this.V0MOV_IMP_INVPERM)}, {FieldThreatment(this.V0MOV_IMP_AMDS)}, {FieldThreatment(this.V0MOV_IMP_AMDS)}, {FieldThreatment(this.V0MOV_IMP_DH)}, {FieldThreatment(this.V0MOV_IMP_DH)}, {FieldThreatment(this.V0MOV_IMP_DIT)}, {FieldThreatment(this.V0MOV_IMP_DIT)}, {FieldThreatment(this.V0MOV_PRM_VG)}, {FieldThreatment(this.V0MOV_PRM_VG)}, {FieldThreatment(this.V0MOV_PRM_AP)}, {FieldThreatment(this.V0MOV_PRM_AP)}, 409, {FieldThreatment(this.V1SIST_DTMOVABE)}, 0, '0' , 'VG0031B' , {FieldThreatment(this.V1SIST_DTMOVABE)},  {FieldThreatment((this.VIND_DT_ADMISSAO?.ToInt() == -1 ? null : this.V0SEG_DT_ADMISSAO))}, NULL,  {FieldThreatment((this.VIND_DT_NASCI?.ToInt() == -1 ? null : this.V0SEG_DT_NASCI))}, NULL, {FieldThreatment(this.V1FATC_DT_REFER)}, {FieldThreatment(this.V1SIST_DTMOVABE)}, NULL, {FieldThreatment(this.V0SEG_LOT_EMP_SEGURADO)})";

            return query;
        }
        public string V0SEG_NUM_APOL { get; set; }
        public string V0SEG_COD_SUBG { get; set; }
        public string V0SEG_COD_FONTE { get; set; }
        public string V0FONTE_PROPAUTOM { get; set; }
        public string V0SEG_TP_SEGURADO { get; set; }
        public string V0SEG_NUM_CERTIF { get; set; }
        public string V0SEG_DAC_CERTIF { get; set; }
        public string V0SEG_TP_INCLUSAO { get; set; }
        public string V0SEG_COD_CLIENTE { get; set; }
        public string V0SEG_AGENCIADOR { get; set; }
        public string V0SEG_CORRETOR { get; set; }
        public string V0SEG_CD_PLANOVGAP { get; set; }
        public string V0SEG_CD_PLANOAP { get; set; }
        public string V0SEG_FAIXA { get; set; }
        public string V0SEG_AUT_AUM_AUT { get; set; }
        public string V0SEG_TP_BENEFICIA { get; set; }
        public string V0SEG_PERI_PGTO { get; set; }
        public string V0SEG_PERI_RENOVA { get; set; }
        public string V0SEG_COD_OCUPACAO { get; set; }
        public string V0SEG_EST_CIVIL { get; set; }
        public string V0SEG_SEXO { get; set; }
        public string V0SEG_CD_PROFISSAO { get; set; }
        public string V0SEG_NATURALIDADE { get; set; }
        public string V0SEG_OCOR_ENDERE { get; set; }
        public string V0SEG_OCOR_END_COB { get; set; }
        public string V0SEG_BCO_COBRANCA { get; set; }
        public string V0SEG_AGE_COBRANCA { get; set; }
        public string V0SEG_DAC_COBRANCA { get; set; }
        public string V0SEG_NUM_MATRIC { get; set; }
        public string V0CTAC_NUM_CTA_COR { get; set; }
        public string V0CTAC_DAC_CTA_COR { get; set; }
        public string V0SEG_VAL_SALARIO { get; set; }
        public string V0SEG_TP_SALARIO { get; set; }
        public string V0SEG_TP_PLANO { get; set; }
        public string V0SEG_PCT_CONJ_VG { get; set; }
        public string V0SEG_PCT_CONJ_AP { get; set; }
        public string V0SEG_QTD_S_MONATU { get; set; }
        public string V0SEG_QTD_S_MOACID { get; set; }
        public string V0SEG_QTD_S_INVPER { get; set; }
        public string V0SEG_TX_AP_MOACID { get; set; }
        public string V0SEG_TX_AP_INVPER { get; set; }
        public string V0SEG_TX_AP_AMDS { get; set; }
        public string V0SEG_TX_AP_DH { get; set; }
        public string V0SEG_TX_AP_DIT { get; set; }
        public string V0SEG_TAXA_VG { get; set; }
        public string V0MOV_IMP_MORNATU { get; set; }
        public string V0MOV_IMP_MORACID { get; set; }
        public string V0MOV_IMP_INVPERM { get; set; }
        public string V0MOV_IMP_AMDS { get; set; }
        public string V0MOV_IMP_DH { get; set; }
        public string V0MOV_IMP_DIT { get; set; }
        public string V0MOV_PRM_VG { get; set; }
        public string V0MOV_PRM_AP { get; set; }
        public string V1SIST_DTMOVABE { get; set; }
        public string V0SEG_DT_ADMISSAO { get; set; }
        public string VIND_DT_ADMISSAO { get; set; }
        public string V0SEG_DT_NASCI { get; set; }
        public string VIND_DT_NASCI { get; set; }
        public string V1FATC_DT_REFER { get; set; }
        public string V0SEG_LOT_EMP_SEGURADO { get; set; }

        public static void Execute(R0224_55_CANCELA_SEGURADO_DB_INSERT_1_Insert1 r0224_55_CANCELA_SEGURADO_DB_INSERT_1_Insert1)
        {
            var ths = r0224_55_CANCELA_SEGURADO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0224_55_CANCELA_SEGURADO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}