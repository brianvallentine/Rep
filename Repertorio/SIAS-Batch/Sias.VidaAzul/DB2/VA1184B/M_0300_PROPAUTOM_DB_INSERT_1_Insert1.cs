using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA1184B
{
    public class M_0300_PROPAUTOM_DB_INSERT_1_Insert1 : QueryBasis<M_0300_PROPAUTOM_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0MOVIMENTO
            VALUES (:RELATO-NUM-APOLICE,
            :RELATO-CODSUBES,
            :PROPVA-FONTE,
            :FONTE-PROPAUTOM,
            '1' ,
            :RELATO-NRCERTIF,
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
            ' ' ,
            ' ' ,
            0,
            ' ' ,
            1,
            1,
            104,
            :OPCAOP-AGECTADEB,
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
            0,
            0,
            0,
            0,
            0,
            0,
            :COBERP-IMPMORNATU-ANT,
            :COBERP-IMPMORNATU-ATU,
            :COBERP-IMPMORACID-ANT,
            :COBERP-IMPMORACID-ATU,
            :COBERP-IMPINVPERM-ANT,
            :COBERP-IMPINVPERM-ATU,
            :COBERP-IMPAMDS-ANT,
            :COBERP-IMPAMDS-ATU,
            :COBERP-IMPDH-ANT,
            :COBERP-IMPDH-ATU,
            :COBERP-IMPDIT-ANT,
            :COBERP-IMPDIT-ATU,
            :COBERP-PRMVG-ANT,
            :COBERP-PRMVG-ATU,
            :COBERP-PRMAP-ANT,
            :COBERP-PRMAP-ATU,
            :RELATO-OPERACAO,
            :SISTEMA-DTMOVABE,
            0,
            '1' ,
            'VA1184B' ,
            :SISTEMA-DTMOVABE,
            NULL,
            NULL,
            :CLIENT-DTNASC,
            NULL,
            :RELATO-DTSOLICITACAO,
            :RELATO-DTSOLICITACAO,
            NULL,
            :SEGURA-LOT-EMP-SEGURADO)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0MOVIMENTO VALUES ({FieldThreatment(this.RELATO_NUM_APOLICE)}, {FieldThreatment(this.RELATO_CODSUBES)}, {FieldThreatment(this.PROPVA_FONTE)}, {FieldThreatment(this.FONTE_PROPAUTOM)}, '1' , {FieldThreatment(this.RELATO_NRCERTIF)}, ' ' , '4' , {FieldThreatment(this.PROPVA_CODCLIEN)}, 0, 0, 0, 0, {FieldThreatment(this.SEGURA_FAIXA)}, 'S' , 'S' , {FieldThreatment(this.OPCAOP_PERIPGTO)}, 12, ' ' , ' ' , ' ' , 0, ' ' , 1, 1, 104, {FieldThreatment(this.OPCAOP_AGECTADEB)}, ' ' , 0, {FieldThreatment(this.MNUM_CTA_CORRENTE)}, {FieldThreatment(this.MDAC_CTA_CORRENTE)}, 0, ' ' , '1' , 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, {FieldThreatment(this.COBERP_IMPMORNATU_ANT)}, {FieldThreatment(this.COBERP_IMPMORNATU_ATU)}, {FieldThreatment(this.COBERP_IMPMORACID_ANT)}, {FieldThreatment(this.COBERP_IMPMORACID_ATU)}, {FieldThreatment(this.COBERP_IMPINVPERM_ANT)}, {FieldThreatment(this.COBERP_IMPINVPERM_ATU)}, {FieldThreatment(this.COBERP_IMPAMDS_ANT)}, {FieldThreatment(this.COBERP_IMPAMDS_ATU)}, {FieldThreatment(this.COBERP_IMPDH_ANT)}, {FieldThreatment(this.COBERP_IMPDH_ATU)}, {FieldThreatment(this.COBERP_IMPDIT_ANT)}, {FieldThreatment(this.COBERP_IMPDIT_ATU)}, {FieldThreatment(this.COBERP_PRMVG_ANT)}, {FieldThreatment(this.COBERP_PRMVG_ATU)}, {FieldThreatment(this.COBERP_PRMAP_ANT)}, {FieldThreatment(this.COBERP_PRMAP_ATU)}, {FieldThreatment(this.RELATO_OPERACAO)}, {FieldThreatment(this.SISTEMA_DTMOVABE)}, 0, '1' , 'VA1184B' , {FieldThreatment(this.SISTEMA_DTMOVABE)}, NULL, NULL, {FieldThreatment(this.CLIENT_DTNASC)}, NULL, {FieldThreatment(this.RELATO_DTSOLICITACAO)}, {FieldThreatment(this.RELATO_DTSOLICITACAO)}, NULL, {FieldThreatment(this.SEGURA_LOT_EMP_SEGURADO)})";

            return query;
        }
        public string RELATO_NUM_APOLICE { get; set; }
        public string RELATO_CODSUBES { get; set; }
        public string PROPVA_FONTE { get; set; }
        public string FONTE_PROPAUTOM { get; set; }
        public string RELATO_NRCERTIF { get; set; }
        public string PROPVA_CODCLIEN { get; set; }
        public string SEGURA_FAIXA { get; set; }
        public string OPCAOP_PERIPGTO { get; set; }
        public string OPCAOP_AGECTADEB { get; set; }
        public string MNUM_CTA_CORRENTE { get; set; }
        public string MDAC_CTA_CORRENTE { get; set; }
        public string COBERP_IMPMORNATU_ANT { get; set; }
        public string COBERP_IMPMORNATU_ATU { get; set; }
        public string COBERP_IMPMORACID_ANT { get; set; }
        public string COBERP_IMPMORACID_ATU { get; set; }
        public string COBERP_IMPINVPERM_ANT { get; set; }
        public string COBERP_IMPINVPERM_ATU { get; set; }
        public string COBERP_IMPAMDS_ANT { get; set; }
        public string COBERP_IMPAMDS_ATU { get; set; }
        public string COBERP_IMPDH_ANT { get; set; }
        public string COBERP_IMPDH_ATU { get; set; }
        public string COBERP_IMPDIT_ANT { get; set; }
        public string COBERP_IMPDIT_ATU { get; set; }
        public string COBERP_PRMVG_ANT { get; set; }
        public string COBERP_PRMVG_ATU { get; set; }
        public string COBERP_PRMAP_ANT { get; set; }
        public string COBERP_PRMAP_ATU { get; set; }
        public string RELATO_OPERACAO { get; set; }
        public string SISTEMA_DTMOVABE { get; set; }
        public string CLIENT_DTNASC { get; set; }
        public string RELATO_DTSOLICITACAO { get; set; }
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