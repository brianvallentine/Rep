using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0130B
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
            895,
            :SISTEMA-DTMOVABE,
            0,
            '1' ,
            'VA0130B' ,
            :SISTEMA-DTMOVABE,
            NULL,
            NULL,
            :CLIENT-DTNASC,
            NULL,
            :SISTEMA-DTMAXALTIGPM,
            :COBERP-DTINIVIG,
            NULL,
            :SEGURA-LOT-EMP-SEGURADO)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0MOVIMENTO VALUES ({FieldThreatment(this.PROPVA_NUM_APOLICE)}, {FieldThreatment(this.PROPVA_CODSUBES)}, {FieldThreatment(this.PROPVA_FONTE)}, {FieldThreatment(this.FONTE_PROPAUTOM)}, '1' , {FieldThreatment(this.PROPVA_NRCERTIF)}, ' ' , '4' , {FieldThreatment(this.PROPVA_CODCLIEN)}, 0, 0, 0, 0, {FieldThreatment(this.SEGURA_FAIXA)}, 'S' , 'S' , {FieldThreatment(this.OPCAOP_PERIPGTO)}, 12, ' ' , {FieldThreatment(this.PROPVA_EST_CIV)}, {FieldThreatment(this.PROPVA_SEXO)}, 0, ' ' , 1, 1, 104, {FieldThreatment(this.PROPVA_AGECOBR)}, ' ' , 0, {FieldThreatment(this.MNUM_CTA_CORRENTE)}, {FieldThreatment(this.MDAC_CTA_CORRENTE)}, 0, ' ' , '1' , 0, 0, 0, 0, 0, {FieldThreatment(this.SEGURA_TXAPMA)}, {FieldThreatment(this.SEGURA_TXAPIP)}, {FieldThreatment(this.SEGURA_TXAPAMDS)}, {FieldThreatment(this.SEGURA_TXAPDH)}, {FieldThreatment(this.SEGURA_TXAPDIT)}, {FieldThreatment(this.SEGURA_TXVG)}, {FieldThreatment(this.COBERP_IMPMORNATU_ANT)}, {FieldThreatment(this.COBERP_IMPMORNATU_ATU)}, {FieldThreatment(this.COBERP_IMPMORACID_ANT)}, {FieldThreatment(this.COBERP_IMPMORACID_ATU)}, {FieldThreatment(this.COBERP_IMPINVPERM_ANT)}, {FieldThreatment(this.COBERP_IMPINVPERM_ATU)}, {FieldThreatment(this.COBERP_IMPAMDS_ANT)}, {FieldThreatment(this.COBERP_IMPAMDS_ATU)}, {FieldThreatment(this.COBERP_IMPDH_ANT)}, {FieldThreatment(this.COBERP_IMPDH_ATU)}, {FieldThreatment(this.COBERP_IMPDIT_ANT)}, {FieldThreatment(this.COBERP_IMPDIT_ATU)}, {FieldThreatment(this.COBERP_PRMVG_ANT)}, {FieldThreatment(this.COBERP_PRMVG_ATU)}, {FieldThreatment(this.COBERP_PRMAP_ANT)}, {FieldThreatment(this.COBERP_PRMAP_ATU)}, 895, {FieldThreatment(this.SISTEMA_DTMOVABE)}, 0, '1' , 'VA0130B' , {FieldThreatment(this.SISTEMA_DTMOVABE)}, NULL, NULL, {FieldThreatment(this.CLIENT_DTNASC)}, NULL, {FieldThreatment(this.SISTEMA_DTMAXALTIGPM)}, {FieldThreatment(this.COBERP_DTINIVIG)}, NULL, {FieldThreatment(this.SEGURA_LOT_EMP_SEGURADO)})";

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
        public string SISTEMA_DTMOVABE { get; set; }
        public string CLIENT_DTNASC { get; set; }
        public string SISTEMA_DTMAXALTIGPM { get; set; }
        public string COBERP_DTINIVIG { get; set; }
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