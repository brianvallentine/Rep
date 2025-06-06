using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0075B
{
    public class R4050_00_TRATA_COMISSAO_DB_INSERT_1_Insert1 : QueryBasis<R4050_00_TRATA_COMISSAO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT
            INTO SEGUROS.V0COMISSAO
            VALUES (:V0COMI-NUMAPOL ,
            :V0COMI-NRENDOS ,
            :V0COMI-NRCERTIF ,
            :V0COMI-DIGCERT ,
            :V0COMI-IDTPSEGU ,
            :V0COMI-NRPARCEL ,
            :V0COMI-OPERACAO ,
            :V0COMI-CODPDT ,
            :V0COMI-RAMOFR ,
            :V0COMI-MODALIFR ,
            :V0COMI-OCORHIST ,
            :V0COMI-FONTE ,
            :V0COMI-CODCLIEN ,
            :V0COMI-VLCOMIS ,
            :V0COMI-DATCLO ,
            :V0COMI-NUMREC ,
            :V0COMI-VALBAS ,
            :V0COMI-TIPCOM ,
            :V0COMI-QTPARCEL ,
            :V0COMI-PCCOMCOR ,
            :V0COMI-PCDESCON ,
            :V0COMI-CODSUBES ,
            CURRENT TIME ,
            :V0COMI-DTMOVTO:VIND-DTMOVTO ,
            :V0COMI-DATSEL:VIND-DATSEL ,
            :V0COMI-CODEMP:VIND-CODEMP ,
            :V0COMI-CODPRP:VIND-CODPRP ,
            CURRENT TIMESTAMP ,
            :V0COMI-NUMBIL:VIND-NUMBIL ,
            :V0COMI-VLVARMON:VIND-VLVARMON ,
            :V0COMI-DTQITBCO:VIND-DTQITBCO2)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0COMISSAO VALUES ({FieldThreatment(this.V0COMI_NUMAPOL)} , {FieldThreatment(this.V0COMI_NRENDOS)} , {FieldThreatment(this.V0COMI_NRCERTIF)} , {FieldThreatment(this.V0COMI_DIGCERT)} , {FieldThreatment(this.V0COMI_IDTPSEGU)} , {FieldThreatment(this.V0COMI_NRPARCEL)} , {FieldThreatment(this.V0COMI_OPERACAO)} , {FieldThreatment(this.V0COMI_CODPDT)} , {FieldThreatment(this.V0COMI_RAMOFR)} , {FieldThreatment(this.V0COMI_MODALIFR)} , {FieldThreatment(this.V0COMI_OCORHIST)} , {FieldThreatment(this.V0COMI_FONTE)} , {FieldThreatment(this.V0COMI_CODCLIEN)} , {FieldThreatment(this.V0COMI_VLCOMIS)} , {FieldThreatment(this.V0COMI_DATCLO)} , {FieldThreatment(this.V0COMI_NUMREC)} , {FieldThreatment(this.V0COMI_VALBAS)} , {FieldThreatment(this.V0COMI_TIPCOM)} , {FieldThreatment(this.V0COMI_QTPARCEL)} , {FieldThreatment(this.V0COMI_PCCOMCOR)} , {FieldThreatment(this.V0COMI_PCDESCON)} , {FieldThreatment(this.V0COMI_CODSUBES)} , CURRENT TIME ,  {FieldThreatment((this.VIND_DTMOVTO?.ToInt() == -1 ? null : this.V0COMI_DTMOVTO))} ,  {FieldThreatment((this.VIND_DATSEL?.ToInt() == -1 ? null : this.V0COMI_DATSEL))} ,  {FieldThreatment((this.VIND_CODEMP?.ToInt() == -1 ? null : this.V0COMI_CODEMP))} ,  {FieldThreatment((this.VIND_CODPRP?.ToInt() == -1 ? null : this.V0COMI_CODPRP))} , CURRENT TIMESTAMP ,  {FieldThreatment((this.VIND_NUMBIL?.ToInt() == -1 ? null : this.V0COMI_NUMBIL))} ,  {FieldThreatment((this.VIND_VLVARMON?.ToInt() == -1 ? null : this.V0COMI_VLVARMON))} ,  {FieldThreatment((this.VIND_DTQITBCO2?.ToInt() == -1 ? null : this.V0COMI_DTQITBCO))})";

            return query;
        }
        public string V0COMI_NUMAPOL { get; set; }
        public string V0COMI_NRENDOS { get; set; }
        public string V0COMI_NRCERTIF { get; set; }
        public string V0COMI_DIGCERT { get; set; }
        public string V0COMI_IDTPSEGU { get; set; }
        public string V0COMI_NRPARCEL { get; set; }
        public string V0COMI_OPERACAO { get; set; }
        public string V0COMI_CODPDT { get; set; }
        public string V0COMI_RAMOFR { get; set; }
        public string V0COMI_MODALIFR { get; set; }
        public string V0COMI_OCORHIST { get; set; }
        public string V0COMI_FONTE { get; set; }
        public string V0COMI_CODCLIEN { get; set; }
        public string V0COMI_VLCOMIS { get; set; }
        public string V0COMI_DATCLO { get; set; }
        public string V0COMI_NUMREC { get; set; }
        public string V0COMI_VALBAS { get; set; }
        public string V0COMI_TIPCOM { get; set; }
        public string V0COMI_QTPARCEL { get; set; }
        public string V0COMI_PCCOMCOR { get; set; }
        public string V0COMI_PCDESCON { get; set; }
        public string V0COMI_CODSUBES { get; set; }
        public string V0COMI_DTMOVTO { get; set; }
        public string VIND_DTMOVTO { get; set; }
        public string V0COMI_DATSEL { get; set; }
        public string VIND_DATSEL { get; set; }
        public string V0COMI_CODEMP { get; set; }
        public string VIND_CODEMP { get; set; }
        public string V0COMI_CODPRP { get; set; }
        public string VIND_CODPRP { get; set; }
        public string V0COMI_NUMBIL { get; set; }
        public string VIND_NUMBIL { get; set; }
        public string V0COMI_VLVARMON { get; set; }
        public string VIND_VLVARMON { get; set; }
        public string V0COMI_DTQITBCO { get; set; }
        public string VIND_DTQITBCO2 { get; set; }

        public static void Execute(R4050_00_TRATA_COMISSAO_DB_INSERT_1_Insert1 r4050_00_TRATA_COMISSAO_DB_INSERT_1_Insert1)
        {
            var ths = r4050_00_TRATA_COMISSAO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R4050_00_TRATA_COMISSAO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}