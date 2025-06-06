using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.FederalVida.DB2.VF0118B
{
    public class M_2000_INTEGRA_VG_DB_INSERT_1_Insert1 : QueryBasis<M_2000_INTEGRA_VG_DB_INSERT_1_Insert1>
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
            :MTPINCLUS,
            :PROPVA-CODCLIEN,
            0,
            0,
            0,
            0,
            :MFAIXA,
            'S' ,
            :MTPBENEF,
            :OPCAOP-PERIPGTO,
            12,
            ' ' ,
            ' ' ,
            :PROPVA-SEXO,
            0,
            ' ' ,
            1,
            1,
            104,
            :MAGECOBR,
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
            :MTXAPMA,
            :MTXAPIP,
            0,
            0,
            0,
            :MTXVG,
            0,
            :COBERP-IMPMORNATU,
            0,
            :COBERP-IMPMORACID,
            0,
            :COBERP-IMPINVPERM,
            0,
            0,
            0,
            0,
            0,
            :COBERP-IMPDIT,
            0,
            :COBERP-PRMVG,
            0,
            :COBERP-PRMAP,
            102,
            :SISTEMA-DTMOVABE,
            0,
            '1' ,
            :PROPVA-CODUSU,
            :SISTEMA-DTMOVABE,
            NULL,
            NULL,
            :CLIENT-DTNASC,
            NULL,
            :MDTREF,
            :MDTMOVTO,
            NULL,
            NULL)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0MOVIMENTO VALUES ({FieldThreatment(this.PROPVA_NUM_APOLICE)}, {FieldThreatment(this.PROPVA_CODSUBES)}, {FieldThreatment(this.PROPVA_FONTE)}, {FieldThreatment(this.FONTE_PROPAUTOM)}, '1' , {FieldThreatment(this.PROPVA_NRCERTIF)}, ' ' , {FieldThreatment(this.MTPINCLUS)}, {FieldThreatment(this.PROPVA_CODCLIEN)}, 0, 0, 0, 0, {FieldThreatment(this.MFAIXA)}, 'S' , {FieldThreatment(this.MTPBENEF)}, {FieldThreatment(this.OPCAOP_PERIPGTO)}, 12, ' ' , ' ' , {FieldThreatment(this.PROPVA_SEXO)}, 0, ' ' , 1, 1, 104, {FieldThreatment(this.MAGECOBR)}, ' ' , 0, {FieldThreatment(this.MNUM_CTA_CORRENTE)}, {FieldThreatment(this.MDAC_CTA_CORRENTE)}, 0, ' ' , '1' , 0, 0, 0, 0, 0, {FieldThreatment(this.MTXAPMA)}, {FieldThreatment(this.MTXAPIP)}, 0, 0, 0, {FieldThreatment(this.MTXVG)}, 0, {FieldThreatment(this.COBERP_IMPMORNATU)}, 0, {FieldThreatment(this.COBERP_IMPMORACID)}, 0, {FieldThreatment(this.COBERP_IMPINVPERM)}, 0, 0, 0, 0, 0, {FieldThreatment(this.COBERP_IMPDIT)}, 0, {FieldThreatment(this.COBERP_PRMVG)}, 0, {FieldThreatment(this.COBERP_PRMAP)}, 102, {FieldThreatment(this.SISTEMA_DTMOVABE)}, 0, '1' , {FieldThreatment(this.PROPVA_CODUSU)}, {FieldThreatment(this.SISTEMA_DTMOVABE)}, NULL, NULL, {FieldThreatment(this.CLIENT_DTNASC)}, NULL, {FieldThreatment(this.MDTREF)}, {FieldThreatment(this.MDTMOVTO)}, NULL, NULL)";

            return query;
        }
        public string PROPVA_NUM_APOLICE { get; set; }
        public string PROPVA_CODSUBES { get; set; }
        public string PROPVA_FONTE { get; set; }
        public string FONTE_PROPAUTOM { get; set; }
        public string PROPVA_NRCERTIF { get; set; }
        public string MTPINCLUS { get; set; }
        public string PROPVA_CODCLIEN { get; set; }
        public string MFAIXA { get; set; }
        public string MTPBENEF { get; set; }
        public string OPCAOP_PERIPGTO { get; set; }
        public string PROPVA_SEXO { get; set; }
        public string MAGECOBR { get; set; }
        public string MNUM_CTA_CORRENTE { get; set; }
        public string MDAC_CTA_CORRENTE { get; set; }
        public string MTXAPMA { get; set; }
        public string MTXAPIP { get; set; }
        public string MTXVG { get; set; }
        public string COBERP_IMPMORNATU { get; set; }
        public string COBERP_IMPMORACID { get; set; }
        public string COBERP_IMPINVPERM { get; set; }
        public string COBERP_IMPDIT { get; set; }
        public string COBERP_PRMVG { get; set; }
        public string COBERP_PRMAP { get; set; }
        public string SISTEMA_DTMOVABE { get; set; }
        public string PROPVA_CODUSU { get; set; }
        public string CLIENT_DTNASC { get; set; }
        public string MDTREF { get; set; }
        public string MDTMOVTO { get; set; }

        public static void Execute(M_2000_INTEGRA_VG_DB_INSERT_1_Insert1 m_2000_INTEGRA_VG_DB_INSERT_1_Insert1)
        {
            var ths = m_2000_INTEGRA_VG_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_2000_INTEGRA_VG_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}