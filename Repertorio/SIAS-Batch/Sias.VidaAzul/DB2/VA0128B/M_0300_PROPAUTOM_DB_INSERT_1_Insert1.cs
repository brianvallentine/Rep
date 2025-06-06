using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0128B
{
    public class M_0300_PROPAUTOM_DB_INSERT_1_Insert1 : QueryBasis<M_0300_PROPAUTOM_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0MOVIMENTO
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
            :SEGURA-FAIXA,
            'S' ,
            'S' ,
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
            :PROPVA-AGECOBR,
            ' ' ,
            0,
            :MNUM-CTA-CORRENTE,
            :MDAC-CTA-CORRENTE,
            0,
            ' ' ,
            '1' ,
            0,
            0,
            0,
            0,
            0,
            :SEGURA-TXAPMA,
            :SEGURA-TXAPIP,
            :SEGURA-TXAPAMDS,
            :SEGURA-TXAPDH,
            :SEGURA-TXAPDIT,
            :SEGURA-TXVG,
            :LK-PU-MORTE-NATURAL,
            :LK-PU-MORTE-NATURAL,
            :LK-PU-MORTE-ACIDENTAL,
            :LK-PU-MORTE-ACIDENTAL,
            :LK-PU-INV-PERMANENTE,
            :LK-PU-INV-PERMANENTE,
            :LK-PU-ASS-MEDICA,
            :LK-PU-ASS-MEDICA,
            :LK-PU-DI-HOSPITALAR,
            :LK-PU-DI-HOSPITALAR,
            :LK-PU-DI-INTERNACAO,
            :LK-PU-DI-INTERNACAO,
            :HISCOBPR-PRMVG,
            :COBERP-PRMVG-ATU,
            :HISCOBPR-PRMAP,
            :COBERP-PRMAP-ATU,
            :COD-OPERACAO,
            :SISTEMA-DTMOVABE,
            0,
            '1' ,
            'VA0128B' ,
            :SISTEMA-DTMOVABE,
            NULL,
            NULL,
            :CLIENT-DTNASC,
            NULL,
            :SISTEMA-DTMOVABE,
            :DATA-MOVIMENTO,
            NULL,
            :SEGURA-LOT-EMP-SEGURADO)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0MOVIMENTO VALUES ({FieldThreatment(this.PROPVA_NUM_APOLICE)}, {FieldThreatment(this.PROPVA_CODSUBES)}, {FieldThreatment(this.PROPVA_FONTE)}, {FieldThreatment(this.FONTE_PROPAUTOM)}, '1' , {FieldThreatment(this.PROPVA_NRCERTIF)}, ' ' , '4' , {FieldThreatment(this.PROPVA_CODCLIEN)}, 0, 0, 0, 0, {FieldThreatment(this.SEGURA_FAIXA)}, 'S' , 'S' , {FieldThreatment(this.OPCAOP_PERIPGTO)}, 12, ' ' , {FieldThreatment(this.PROPVA_EST_CIV)}, {FieldThreatment(this.PROPVA_SEXO)}, 0, ' ' , 1, 1, 104, {FieldThreatment(this.PROPVA_AGECOBR)}, ' ' , 0, {FieldThreatment(this.MNUM_CTA_CORRENTE)}, {FieldThreatment(this.MDAC_CTA_CORRENTE)}, 0, ' ' , '1' , 0, 0, 0, 0, 0, {FieldThreatment(this.SEGURA_TXAPMA)}, {FieldThreatment(this.SEGURA_TXAPIP)}, {FieldThreatment(this.SEGURA_TXAPAMDS)}, {FieldThreatment(this.SEGURA_TXAPDH)}, {FieldThreatment(this.SEGURA_TXAPDIT)}, {FieldThreatment(this.SEGURA_TXVG)}, {FieldThreatment(this.LK_PU_MORTE_NATURAL)}, {FieldThreatment(this.LK_PU_MORTE_NATURAL)}, {FieldThreatment(this.LK_PU_MORTE_ACIDENTAL)}, {FieldThreatment(this.LK_PU_MORTE_ACIDENTAL)}, {FieldThreatment(this.LK_PU_INV_PERMANENTE)}, {FieldThreatment(this.LK_PU_INV_PERMANENTE)}, {FieldThreatment(this.LK_PU_ASS_MEDICA)}, {FieldThreatment(this.LK_PU_ASS_MEDICA)}, {FieldThreatment(this.LK_PU_DI_HOSPITALAR)}, {FieldThreatment(this.LK_PU_DI_HOSPITALAR)}, {FieldThreatment(this.LK_PU_DI_INTERNACAO)}, {FieldThreatment(this.LK_PU_DI_INTERNACAO)}, {FieldThreatment(this.HISCOBPR_PRMVG)}, {FieldThreatment(this.COBERP_PRMVG_ATU)}, {FieldThreatment(this.HISCOBPR_PRMAP)}, {FieldThreatment(this.COBERP_PRMAP_ATU)}, {FieldThreatment(this.COD_OPERACAO)}, {FieldThreatment(this.SISTEMA_DTMOVABE)}, 0, '1' , 'VA0128B' , {FieldThreatment(this.SISTEMA_DTMOVABE)}, NULL, NULL, {FieldThreatment(this.CLIENT_DTNASC)}, NULL, {FieldThreatment(this.SISTEMA_DTMOVABE)}, {FieldThreatment(this.DATA_MOVIMENTO)}, NULL, {FieldThreatment(this.SEGURA_LOT_EMP_SEGURADO)})";

            return query;
        }
        public string PROPVA_NUM_APOLICE { get; set; }
        public string PROPVA_CODSUBES { get; set; }
        public string PROPVA_FONTE { get; set; }
        public string FONTE_PROPAUTOM { get; set; }
        public string PROPVA_NRCERTIF { get; set; }
        public string PROPVA_CODCLIEN { get; set; }
        public string SEGURA_FAIXA { get; set; }
        public string OPCAOP_PERIPGTO { get; set; }
        public string PROPVA_EST_CIV { get; set; }
        public string PROPVA_SEXO { get; set; }
        public string PROPVA_AGECOBR { get; set; }
        public string MNUM_CTA_CORRENTE { get; set; }
        public string MDAC_CTA_CORRENTE { get; set; }
        public string SEGURA_TXAPMA { get; set; }
        public string SEGURA_TXAPIP { get; set; }
        public string SEGURA_TXAPAMDS { get; set; }
        public string SEGURA_TXAPDH { get; set; }
        public string SEGURA_TXAPDIT { get; set; }
        public string SEGURA_TXVG { get; set; }
        public string LK_PU_MORTE_NATURAL { get; set; }
        public string LK_PU_MORTE_ACIDENTAL { get; set; }
        public string LK_PU_INV_PERMANENTE { get; set; }
        public string LK_PU_ASS_MEDICA { get; set; }
        public string LK_PU_DI_HOSPITALAR { get; set; }
        public string LK_PU_DI_INTERNACAO { get; set; }
        public string HISCOBPR_PRMVG { get; set; }
        public string COBERP_PRMVG_ATU { get; set; }
        public string HISCOBPR_PRMAP { get; set; }
        public string COBERP_PRMAP_ATU { get; set; }
        public string COD_OPERACAO { get; set; }
        public string SISTEMA_DTMOVABE { get; set; }
        public string CLIENT_DTNASC { get; set; }
        public string DATA_MOVIMENTO { get; set; }
        public string SEGURA_LOT_EMP_SEGURADO { get; set; }

        public static void Execute(M_0300_PROPAUTOM_DB_INSERT_1_Insert1 m_0300_PROPAUTOM_DB_INSERT_1_Insert1)
        {
            var ths = m_0300_PROPAUTOM_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_0300_PROPAUTOM_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}