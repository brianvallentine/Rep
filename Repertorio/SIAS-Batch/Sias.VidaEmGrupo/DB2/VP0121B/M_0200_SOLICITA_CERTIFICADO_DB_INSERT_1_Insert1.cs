using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0121B
{
    public class M_0200_SOLICITA_CERTIFICADO_DB_INSERT_1_Insert1 : QueryBasis<M_0200_SOLICITA_CERTIFICADO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0RELATORIOS
            VALUES ( 'VP0121B' ,
            CURRENT DATE,
            'VA' ,
            :RELATO-CODRELAT,
            0,
            0,
            CURRENT DATE,
            CURRENT DATE,
            CURRENT DATE,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            :PROPVA-NUM-APOLICE,
            0,
            :RELATO-NRPARCEL,
            :PROPVA-NRCERTIF,
            0,
            :PROPVA-CODSUBES,
            :RELATO-OPERACAO,
            0,
            0,
            ' ' ,
            ' ' ,
            0,
            0,
            ' ' ,
            0,
            0,
            ' ' ,
            :WS-SIT-REGISTRO,
            ' ' ,
            ' ' ,
            NULL,
            0,
            0,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0RELATORIOS VALUES ( 'VP0121B' , CURRENT DATE, 'VA' , {FieldThreatment(this.RELATO_CODRELAT)}, 0, 0, CURRENT DATE, CURRENT DATE, CURRENT DATE, 0, 0, 0, 0, 0, 0, 0, 0, {FieldThreatment(this.PROPVA_NUM_APOLICE)}, 0, {FieldThreatment(this.RELATO_NRPARCEL)}, {FieldThreatment(this.PROPVA_NRCERTIF)}, 0, {FieldThreatment(this.PROPVA_CODSUBES)}, {FieldThreatment(this.RELATO_OPERACAO)}, 0, 0, ' ' , ' ' , 0, 0, ' ' , 0, 0, ' ' , {FieldThreatment(this.WS_SIT_REGISTRO)}, ' ' , ' ' , NULL, 0, 0, CURRENT TIMESTAMP)";

            return query;
        }
        public string RELATO_CODRELAT { get; set; }
        public string PROPVA_NUM_APOLICE { get; set; }
        public string RELATO_NRPARCEL { get; set; }
        public string PROPVA_NRCERTIF { get; set; }
        public string PROPVA_CODSUBES { get; set; }
        public string RELATO_OPERACAO { get; set; }
        public string WS_SIT_REGISTRO { get; set; }

        public static void Execute(M_0200_SOLICITA_CERTIFICADO_DB_INSERT_1_Insert1 m_0200_SOLICITA_CERTIFICADO_DB_INSERT_1_Insert1)
        {
            var ths = m_0200_SOLICITA_CERTIFICADO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_0200_SOLICITA_CERTIFICADO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}