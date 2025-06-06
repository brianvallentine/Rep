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
    public class M_1000_PROPAUTOM_DB_INSERT_1_Insert1 : QueryBasis<M_1000_PROPAUTOM_DB_INSERT_1_Insert1>
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
            :PLAVAVGA-FAIXA,
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
            0,
            0,
            0,
            0,
            0,
            0,
            :COBERP-IMPMORNATU-ANT,
            :COBERP-IMPMORNATU-ATU,
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
            :COBERP-PRMVG-ANT,
            :COBERP-PRMVG-ATU,
            0,
            0,
            820,
            :SISTEMA-DTMOVABE,
            0,
            '1' ,
            'VA0130B' ,
            :SISTEMA-DTMOVABE,
            NULL,
            NULL,
            :CLIENT-DTNASC,
            NULL,
            :PROPVA-DTMOVTO,
            :PROPVA-DTMOVTO,
            NULL,
            NULL)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0MOVIMENTO VALUES ({FieldThreatment(this.PROPVA_NUM_APOLICE)}, {FieldThreatment(this.PROPVA_CODSUBES)}, {FieldThreatment(this.PROPVA_FONTE)}, {FieldThreatment(this.FONTE_PROPAUTOM)}, '1' , {FieldThreatment(this.PROPVA_NRCERTIF)}, ' ' , '4' , {FieldThreatment(this.PROPVA_CODCLIEN)}, 0, 0, 0, 0, {FieldThreatment(this.PLAVAVGA_FAIXA)}, 'S' , 'S' , {FieldThreatment(this.OPCAOP_PERIPGTO)}, 12, ' ' , {FieldThreatment(this.PROPVA_EST_CIV)}, {FieldThreatment(this.PROPVA_SEXO)}, 0, ' ' , 1, 1, 104, {FieldThreatment(this.PROPVA_AGECOBR)}, ' ' , 0, {FieldThreatment(this.MNUM_CTA_CORRENTE)}, {FieldThreatment(this.MDAC_CTA_CORRENTE)}, 0, ' ' , '1' , 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, {FieldThreatment(this.COBERP_IMPMORNATU_ANT)}, {FieldThreatment(this.COBERP_IMPMORNATU_ATU)}, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, {FieldThreatment(this.COBERP_PRMVG_ANT)}, {FieldThreatment(this.COBERP_PRMVG_ATU)}, 0, 0, 820, {FieldThreatment(this.SISTEMA_DTMOVABE)}, 0, '1' , 'VA0130B' , {FieldThreatment(this.SISTEMA_DTMOVABE)}, NULL, NULL, {FieldThreatment(this.CLIENT_DTNASC)}, NULL, {FieldThreatment(this.PROPVA_DTMOVTO)}, {FieldThreatment(this.PROPVA_DTMOVTO)}, NULL, NULL)";

            return query;
        }
        public string PROPVA_NUM_APOLICE { get; set; }
        public string PROPVA_CODSUBES { get; set; }
        public string PROPVA_FONTE { get; set; }
        public string FONTE_PROPAUTOM { get; set; }
        public string PROPVA_NRCERTIF { get; set; }
        public string PROPVA_CODCLIEN { get; set; }
        public string PLAVAVGA_FAIXA { get; set; }
        public string OPCAOP_PERIPGTO { get; set; }
        public string PROPVA_EST_CIV { get; set; }
        public string PROPVA_SEXO { get; set; }
        public string PROPVA_AGECOBR { get; set; }
        public string MNUM_CTA_CORRENTE { get; set; }
        public string MDAC_CTA_CORRENTE { get; set; }
        public string COBERP_IMPMORNATU_ANT { get; set; }
        public string COBERP_IMPMORNATU_ATU { get; set; }
        public string COBERP_PRMVG_ANT { get; set; }
        public string COBERP_PRMVG_ATU { get; set; }
        public string SISTEMA_DTMOVABE { get; set; }
        public string CLIENT_DTNASC { get; set; }
        public string PROPVA_DTMOVTO { get; set; }

        public static void Execute(M_1000_PROPAUTOM_DB_INSERT_1_Insert1 m_1000_PROPAUTOM_DB_INSERT_1_Insert1)
        {
            var ths = m_1000_PROPAUTOM_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_1000_PROPAUTOM_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}